using FormaulaTree.Api.Models;

namespace FormaulaTree.Api.Services;

public class ExpressionEvaluator
{
    public TreeNode ConvertToTree(string expression)
    {
        var nodeStack = new Stack<TreeNode>();

        expression = $"({expression})";
        for (var i = 0; i < expression.Length; i++)
        {
            var c = expression[i].ToString().Trim();
            
            if (c != "")
            {
                if (TreeNode.Operators.Contains(c))
                {
                    nodeStack.Push(new TreeNode { Data = c.ToString() });
                }
                else if (c == "(")
                {
                    continue;
                }
                else if (Char.IsNumber(c, 0))
                {
                    var d = Convert.ToDouble(c.ToString());
                    var j = i + 1;
                    while (Char.IsNumber(expression[j]))
                    {
                        d = (d * 10) + Convert.ToDouble(expression[j].ToString());
                        j++;
                    }
                    i = j - 1;
                    nodeStack.Push(new TreeNode { Data = d.ToString() });
                }
                else if (c == ")")
                {
                    var op2Node = nodeStack.Pop();
                    var opNode = nodeStack.Pop();
                    var op1Node = nodeStack.Pop();

                    opNode.Left = op1Node;
                    opNode.Right = op2Node;
                    nodeStack.Push(opNode);
                }
            }
        }

        if (nodeStack.Count == 3)
        {
            var op2Node = nodeStack.Pop();
            var opNode = nodeStack.Pop();
            var op1Node = nodeStack.Pop();
            opNode.Left = op1Node;
            opNode.Right = op2Node;
            nodeStack.Push(opNode);
        }

        var node = nodeStack.Pop();

        return node;
    }
}