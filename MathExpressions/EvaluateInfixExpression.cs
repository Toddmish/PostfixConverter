using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExpressions
{
	/// <summary>
	/// Will serve as a class for evaluating infix expressions
	/// </summary>
    public class EvaluateInfixExpression : MathExpression
    {
        public static double Compute(string infixExp)

        {
            List<Cell> postfixExp = InfixToPostfixConverter.ConvertFromInfixToPostfixCollection(infixExp);
            return Calculate(postfixExp);
        }

        /// <summary>
        /// Intentionally left as private to prevent from calling it with expressions not being in POSTFIX form
        /// </summary>
        /// <param name="postfixExp"></param>
        /// <returns></returns>
        private static Double Calculate(List<Cell> postfixExp)
        {
            Stack<Cell> stack = new Stack<Cell>();
            for (int i = 0; i < postfixExp.Count; i++)
            {
                Cell element = postfixExp[i];
                if (element.GetType().Equals(typeof(NumberCell)))
                    stack.Push(element);
                else if (element.GetType().Equals(typeof(OperatorCell)))
                {
                    try
                    {
                        Func<double, double, double> oper = operators[((OperatorCell)element).ToString()];
                        //applying operator with two operands popped from top of the stack
                        NumberCell result = new NumberCell(oper(((NumberCell)stack.Pop()).getNumber(), ((NumberCell)stack.Pop()).getNumber()).ToString());
                        stack.Push(result);
                    }
                    catch(Exception)
                    {
                        throw new Exception("Unable to apply operator!.");
                    }
                }
            }
            return ((NumberCell)stack.Pop()).getNumber();
        }
    }
}
