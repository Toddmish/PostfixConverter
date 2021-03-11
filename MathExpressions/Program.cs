using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExpressions
{
    class Program
    {
        static void Main (string[] args)
		{
            
			IList<String> examples = new List<String> () {
				"2^2 +100.5 + 300.5 - 100 * 10 / 100 +2^2",
				"4 + 6 + 9 * 8 - (5 * 6 + 9) ^ 2",
				"1 + 2 * 7",
				//"A+B*C",
				"2^2"
			}; 
			examples.ToList ().ForEach (
				e => {
					String postFix = InfixToPostfixConverter.ConvertFromInfixToPostfixExpression (e);
					Console.WriteLine (
						e.ToString ()
						+ "        Postfix        " + postFix
						+ "        Value          " + EvaluateInfixExpression.Compute (e).ToString ()
					);
					Console.WriteLine ();
				}

			);
			Console.ReadLine ();
			//Console.WriteLine(EvaluateInfixExpression.Compute(Console.ReadLine()));
			//Console.WriteLine(Version5.convertToPrefix(str3));
			Console.ReadKey ();
		}

	}
}
