public class Program
{
    public static void Main(string[] args)
    {
        var evaluator = new FormaulaTree.FormaulaEvaluator();
        var input = "(3 + 4) + (2 * 7)";
        // var input = "(15 + (7 - (1 + 1) ) ) * 3 ) - (2 + (1 + 1)";
        var result = evaluator.CreateTree(input);

        Console.WriteLine(result.Calculate());
    }
}