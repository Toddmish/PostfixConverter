using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MathExpressions
{
	/// <summary>
	/// Will serve as a class for converting  infix to postfix expressions
	/// </summary>
    public class InfixToPostfixConverter : MathExpression
    {
        
        public static string ConvertFromInfixToPostfixExpression(string infix)
        {
            List<Cell> infixList = Parse(infix);
            return ConvertFromInfixToPostfixExpression(infixList);
        }

       
        
        public static List<Cell> ConvertFromInfixToPostfixCollection(string infix)
        {
            List<Cell> infixList = Parse(infix);
            return ConvertFromInfixToPostfixCollection(infixList);
        }


        private static string ConvertFromInfixToPostfixExpression(List<Cell> infix)
        {
            List<Cell> postfixList = ConvertFromInfixToPostfixCollection(infix);
            StringBuilder s = new StringBuilder();
            foreach (var c in postfixList)
                s.Append(c.ToString() + " ");
            return s.ToString().TrimEnd();
        }
        private static List<Cell> ConvertFromInfixToPostfixCollection(List<Cell> infixVersionInput)
        {
            List<Cell> infixVersionCopy = new List<Cell>(infixVersionInput);
            List<Cell> postfixVersion = new List<Cell>();
            Stack<Cell> st = new Stack<Cell>();
            for (int i = 0; i < infixVersionCopy.Count; i++)
            {
                Cell element = infixVersionCopy[i];
                if (element.GetType().Equals(typeof(NumberCell)))
                    postfixVersion.Add(element);
                //otherwise the symbol is operator
                else
                {
                    //the simplest case of pushing an operator-i.e when stach is empty or a left bracket is on top of the stack
                    if (st.Count == 0 ||
                            ((OperatorCell)element).type == OperatorType.LEFTBRACKET)
                        st.Push(element);
                    else
                    {
                        Cell top = st.First();
                        //if end of bracket's expression
                        if (((OperatorCell)element).type == OperatorType.RIGHTBRACKET)
                            PullOperatorsFromStack(postfixVersion, st, element, top);
                        else if (Precedence((OperatorCell)element) < Precedence((OperatorCell)top))
                            st.Push(element);
                        else
                        {
                            PullOperatorsFromStack(postfixVersion, st, element, top);
                            st.Push(element);
                        }
                    }
                }

            }

            //pop all operators remained in stack
            while (st.Count > 0)
            {
                Cell el = st.Pop();
                postfixVersion.Add(el);
            }

            return postfixVersion;
        }

        private static int Precedence(OperatorCell c)
        {
            if (c.type == OperatorType.EXPONENTIAL)
                return 2;
            else if (c.type == OperatorType.MULTIPLY || c.type == OperatorType.DIVIDE)
                return 3;
            else if (c.type == OperatorType.ADD || c.type == OperatorType.SUBTRACT)
                return 4;
            else
                return Int32.MaxValue;
        }
        /// <summary>
        /// Pops operators from stack which have higher priority then current one
        /// </summary>
        /// <param name="operatorsStack"></param>
        /// <param name="element"></param>
        /// <param name="top"></param>
        private static void PullOperatorsFromStack(List<Cell> postFixOutput, Stack<Cell> operatorsStack, Cell element, Cell top)
        {
            while (operatorsStack.Count > 0 && Precedence((OperatorCell)element) >= Precedence((OperatorCell)top))
            {
                Cell p = operatorsStack.Pop();
                if (((OperatorCell)p).type == OperatorType.LEFTBRACKET)
                    break;
                postFixOutput.Add(p);
                if (operatorsStack.Count > 0)
                    top = operatorsStack.First();
            }
        }

        private static List<Cell> Parse(string s)
        {
			s = s.Trim();  //@"\s*[+/*-]\s*"  @"([()*^+\/-])"
            List<Cell> res = new List<Cell>();
			List<String> resList = Regex.Split(s,@"([()*^+\/-])" , RegexOptions.Multiline).ToList();
            while(resList.Remove(""));
            while (resList.Remove(" "));
            foreach (string cell in resList)
            {
                if (IsOperator(cell))
                    res.Add(new OperatorCell(cell.ToCharArray().First()));
                else res.Add(new NumberCell(cell));
            }
            return res;
        }
    }
}
