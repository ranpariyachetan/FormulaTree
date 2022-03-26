var evaluator = new FormaulaTree.FormaulaEvaluator();
var input = "3 + 4 * 9 / 7";
var result = evaluator.EvaluateFormula(input);

Console.WriteLine(result);