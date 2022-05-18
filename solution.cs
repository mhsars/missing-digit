using System;

public class Program
{
	public static void Main()
	{
		var a1 = MissingDigit("4 - 2 = x");
		var a2 = MissingDigit("1x0 * 12 = 1200");
    
		Console.WriteLine(a1);
		Console.WriteLine(a2);
	}

	// Input: "4 - 2 = x" => x = 2
	// Input: "1x0 * 12 = 1200" => x = 0
	public static int xAsInt;
	public static int MissingDigit(string expression)
	{
		int firstOperandAsInt, secondOperandAsInt, result, resultantAsInt;
		string x;
		
		var splittedExpression = expression.Split(' ');
		var firstOperand = splittedExpression[0];
		var operatorSymbol = splittedExpression[1];
		var secondOperand = splittedExpression[2];
		var resultant = splittedExpression[splittedExpression.Length - 1];
		
		// if x in result
		if (resultant.Contains("x"))
		{
			x = resultant;
			firstOperandAsInt = int.Parse(firstOperand);
			secondOperandAsInt = int.Parse(secondOperand);
			
			result = operatorSymbol switch
			{
				"+" => firstOperandAsInt + secondOperandAsInt,
				"-" => firstOperandAsInt - secondOperandAsInt,
				"*" => firstOperandAsInt * secondOperandAsInt,
				_ => firstOperandAsInt / secondOperandAsInt
			};
		}
		// if x in one of operands
		else
		{
			resultantAsInt = int.Parse(resultant);
			// if x in first operand
			if (firstOperand.Contains("x"))
			{
				x = firstOperand;
				secondOperandAsInt = int.Parse(secondOperand);
				
				result = operatorSymbol switch
				{
					"+" => resultantAsInt - secondOperandAsInt,
					"-" => resultantAsInt + secondOperandAsInt,
					"*" => resultantAsInt / secondOperandAsInt,
					_ => resultantAsInt * secondOperandAsInt
				};
			}
			// if x in second operand
			else
			{
				x = secondOperand;
				firstOperandAsInt = int.Parse(firstOperand);
				
				result = operatorSymbol switch
				{
					"+" => resultantAsInt - firstOperandAsInt,
					"-" => firstOperandAsInt - resultantAsInt,
					"*" => resultantAsInt / firstOperandAsInt,
					_ => firstOperandAsInt / resultantAsInt
				};
			}
		}
		
		var resultAsString = result.ToString();
		var k = 0;
		for (var i = 0; i < resultAsString.Length; i++)
		{
			var currentChar = x[k];
			
			if (currentChar == 'x')
			{
				xAsInt = int.Parse(resultAsString[k].ToString());
			}
			else
			{
				k++;
			}
		}

		return xAsInt;
	}
}
