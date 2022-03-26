namespace FormaulaTree;

public class FormaulaEvaluator
{
    private static List<char> operators = new List<char> {'+', '-', '*', '/'};
    public double EvaluateFormula(string input)
    {
		double op1 = 0d;
		double op2 = 0d;
		var op1Found = false;
		char op = '\0' ;
		double answer = 0;
		for(var i = 0;i<input.Length;i++)
		{
			var c = input[i];
			if(c != ' ')
			{
				if(operators.Contains(c))
				{
					op = c;
				}
				else if(Char.IsNumber(c))
				{
					if(!op1Found)
					{
						op1 = Convert.ToDouble(c.ToString());
						op1Found = true;
						continue;
					}
					else
					{
						op2 = Convert.ToDouble(c.ToString());
						answer = PerformCalculation(op1, op2, op);
						op1 = answer;
					}
				}
			}
		}

        return answer;
    }

    private static double PerformCalculation(double op1, double op2, char oper)
	{
		switch (oper)
		{
			case '+':
				return op1 + op2;
			case '-':
				return op1 - op2;
			case '*':
				return op1 * op2;
			case '/':
				return op1 / op2;
			default:
				return 0;
		}
	}
}