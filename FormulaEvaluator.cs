namespace FormaulaTree
{
    public class TreeNode
    {
        public string Data {get;set;}
        public TreeNode Left {get;set;}
        public TreeNode Right {get;set;}
    }
    public class FormaulaEvaluator
    {
        private static List<char> operators = new List<char> {'+', '-', '*', '/'};

        public double EvaluateFormula(string input)
        {
            var stk = new Stack<string>();
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
                        stk.Push(c.ToString());
                        nodeStack.Push(new TreeNode{ Data = c.ToString()});
                    }
                    else if(c == '(')
                    {
                        stk.Push(c.ToString());
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
                        i = j-1;
                        stk.Push(d.ToString());
                        nodeStack.Push(new TreeNode{ Data = d.ToString()});
                    }
                    else if(c == ')')
                    {
                        while(stk.Count > 0)
                        {
                            var op2 = Convert.ToDouble(stk.Pop());
                            var op = stk.Pop();
                            var op1 = Convert.ToDouble( stk.Pop());

                            var op2Node = nodeStack.Pop();
                            var opNode = nodeStack.Pop();
                            var op1Node = nodeStack.Pop();

                            opNode.Left = op1Node;
                            opNode.Right = op2Node;

                            answer = PerformCalculation(op2, op1, op);

                            if(stk.Peek() == "(")
                            {
                                stk.Pop();
                                stk.Push(answer.ToString());
                                nodeStack.Push(opNode);
                                break;
                            }
                        }
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

            return Convert.ToDouble(stk.Pop());
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