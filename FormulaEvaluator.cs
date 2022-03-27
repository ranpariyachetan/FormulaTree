namespace FormaulaTree
{
    public class TreeNode
    {
        private static List<string> operators = new List<string> {"+", "-", "*", "/"};

        public string Data {get;set;}
        public TreeNode Left {get;set;}
        public TreeNode Right {get;set;}

        public double Calculate()
        {
            if(!operators.Contains(Data))
            {
                return Convert.ToDouble(Data);
            }

            var l = Left.Calculate();
            var r = Right.Calculate();

            return PerformCalculation(l, r, Data);
        }

        private static double PerformCalculation(double op1, double op2, string oper)
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
    public class FormaulaEvaluator
    {
        private static List<char> operators = new List<char> {'+', '-', '*', '/'};

        public TreeNode CreateTree(string input)
        {
            var nodeStack = new Stack<TreeNode>();

            input = $"({input})";
            double answer = 0;
            for(var i = 0;i<input.Length;i++)
            {
                var c = input[i];
                if(c != ' ')
                {
                    if(operators.Contains(c))
                    {
                        nodeStack.Push(new TreeNode{ Data = c.ToString()});
                    }
                    else if(c == '(')
                    {
                        continue;
                    }
                    else if(Char.IsNumber(c))
                    {
                        var d = Convert.ToDouble(c.ToString());
                        var j = i + 1;
                        while(Char.IsNumber(input[j]))
                        {
                            d = (d * 10) + Convert.ToDouble(input[j].ToString());
                            j++;
                        }
                        i = j - 1;
                        nodeStack.Push(new TreeNode{ Data = d.ToString()});
                    }
                    else if(c == ')')
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

            if(nodeStack.Count==3)
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

        private static double PerformCalculation(double op1, double op2, string oper)
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
}