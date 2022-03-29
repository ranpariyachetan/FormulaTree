using Microsoft.AspNetCore.Mvc;
using FormaulaTree.Api.Models;
using FormaulaTree.Api.Services;
using System.Text.Json;

namespace FormulaTree.Api.Controllers;

[ApiController]
[Route("api/expr")]
public class ExpressionController : ControllerBase
{
    /// <summary>
    /// Retuns tree and evaluated value of input expression.
    /// </summary>
    /// <param name="model">Model object containing expression.</param>
    /// <returns>Json with expression result and tree representation of expression.</returns>
    [Route("tree")]
    [HttpPost]
    public ActionResult ToTree([FromBody]ExpressionModel model)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var evaluator = new ExpressionEvaluator();
        var node = evaluator.ConvertToTree(model.Expression == null ? "" : model.Expression);

        var answer = node.Calculate();
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
        };

        return new JsonResult(new {Answer = answer, Tree = node}, options);
    }
}