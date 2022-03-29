using Microsoft.AspNetCore.Mvc;
using FormaulaTree.Api.Models;
using FormaulaTree.Api.Services;
using System.Text.Json;

namespace FormulaTree.Api.Controllers;

[ApiController]
[Route("api/expr")]
public class ExpressionController : ControllerBase
{
    [Route("tree")]
    [HttpPost]
    public ActionResult ToTree([FromBody]ExpressionModel model)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var evaluator = new ExpressionEvaluator();
        var node = evaluator.ConvertToTree(model.Expression);

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