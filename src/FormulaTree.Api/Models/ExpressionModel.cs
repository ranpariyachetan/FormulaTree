using System.ComponentModel.DataAnnotations;

namespace FormaulaTree.Api.Models;

public class ExpressionModel
{
    [Required]
    public string? Expression {get;set;}
}