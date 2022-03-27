using System.Text.Json;
public class Program
{
    public static void Main(string[] args)
    {
        var evaluator = new FormaulaTree.FormaulaEvaluator();
        var input = "(3 + 4) + (2 * 7)";
        // var input = "(15 + (7 - (1 + 1) ) ) * 3 ) - (2 + (1 + 1)";
        var result = evaluator.CreateTree(input);

        var options = new JsonSerializerOptions { WriteIndented = true, Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping, IgnoreNullValues = true };

        string jsonString = JsonSerializer.Serialize(result, options);


        Console.WriteLine(result.Calculate());

        Console.WriteLine(jsonString);

        
    }
}