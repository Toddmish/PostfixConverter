using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExpressions
{

    public class MathExpression
    {

        protected static Dictionary<string, Func<double, double, double>> operators = new Dictionary<string, Func<double, double, double>>()
        {
             { "+", (a, b) => a + b},
             { "-", (a, b) => b - a},
             { "*", (a, b) => a * b},
             { "/", (a, b) => b / a},
             { "^", (a, b) => Math.Pow(b, a)},
             { "(", null},
             { ")", null},
        };


        public static bool IsOperator(string op)
        {
            return operators.Keys.Contains(op);
        }

        #region shared types

        public enum OperatorType { MULTIPLY, DIVIDE, ADD, SUBTRACT, EXPONENTIAL, LEFTBRACKET, RIGHTBRACKET };     

        public class NumberCell : Cell
        {
            private double number;
            public Double getNumber()
            {
                return number;
            }

            public NumberCell(String number)
            {
                this.number = Double.Parse(number);
            }

            public override String ToString()
            {
                return ((int)number).ToString();
            }
        }

        public class OperatorCell : Cell
        {
            public OperatorType type;
            private char charToDisplay;
            public OperatorCell(char op)
            {
                charToDisplay = op;
                if (op == '+')
                    type = OperatorType.ADD;
                else if (op == '-')
                    type = OperatorType.SUBTRACT;		
                else if (op == '*')
                    type = OperatorType.MULTIPLY;
                else if (op == '/')
                    type = OperatorType.DIVIDE;
                else if (op == '^')
                    type = OperatorType.EXPONENTIAL;
                else if (op == '(')
                    type = OperatorType.LEFTBRACKET;
                else if (op == ')')
                    type = OperatorType.RIGHTBRACKET;
            }

            public override String ToString()
            {
                return charToDisplay.ToString();
            }

        }

        public interface Cell
        {
        }
        #endregion

    }
}
