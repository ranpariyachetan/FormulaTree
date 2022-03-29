namespace FormaulaTree.Api.Models;

public class TreeNode
{
    // given an input string with basic math operations + - * / n whole numbers (both positive and negative)
    // you must
    // 1. Convert the input string into a binary tree.
    // 2. Produce an answer to the input string.
    public static List<string> Operators = new List<string> { "+", "-", "*", "/" };

    public string? Data { get; set; }
    public TreeNode? Left { get; set; }
    public TreeNode? Right { get; set; }

    public double Calculate()
    {
        if (Data != null && !Operators.Contains(Data))
        {
            return Convert.ToDouble(Data);
        }

        var l = Left == null ? 0 : Left.Calculate();
        var r = Right == null ? 0 : Right.Calculate();

        return PerformCalculation(l, r, Data);
    }

    private static double PerformCalculation(double op1, double op2, string? oper)
    {
        switch (oper)
        {
            case "+":
                return op1 + op2;
            case "-":
                return op1 - op2;
            case "*":
                return op1 * op2;
            case "/":
                return op1 / op2;
            default:
                return 0;
        }
    }
}