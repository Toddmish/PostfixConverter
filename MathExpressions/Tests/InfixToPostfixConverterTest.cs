																																																								using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExpressions.Tests
{
    class InfixToPostfixConverterTest
    { 
        [Test]
        public void ConvertFromInfixToPostfixExpressionTest()
        {
       
            Assert.AreEqual("1 2 3 * +", InfixToPostfixConverter.ConvertFromInfixToPostfixExpression(" 1 + 2  * 3"));
            Assert.AreEqual("1 2 * 3 +", InfixToPostfixConverter.ConvertFromInfixToPostfixExpression("1 * 2 + 3"));
            Assert.AreEqual("3 2 1 + *", InfixToPostfixConverter.ConvertFromInfixToPostfixExpression("3 * ( 2 + 1 ) "));

            Assert.AreEqual("6 2 - 3 +", InfixToPostfixConverter.ConvertFromInfixToPostfixExpression(" 6 - 2  + 3"));
            Assert.AreEqual("7 8 9 ^ * 6 +", InfixToPostfixConverter.ConvertFromInfixToPostfixExpression("7 * 8 ^ 9 + 6"));
            Assert.AreEqual("7 8 9 10 * + * 11 +", InfixToPostfixConverter.ConvertFromInfixToPostfixExpression("7 * (8 + 9 * 10) + 11"));
            Assert.AreEqual("7 8 9 10 * + * 11 +", InfixToPostfixConverter.ConvertFromInfixToPostfixExpression("7  * (8+9* 10) +  11"));



            Assert.AreNotEqual("+ 1 2 3 *", InfixToPostfixConverter.ConvertFromInfixToPostfixExpression(" 1 + 2  * 3"));
            Assert.AreNotEqual("1 * 2  3 +", InfixToPostfixConverter.ConvertFromInfixToPostfixExpression("1 * 2 + 3"));
            Assert.AreNotEqual("3 2 + 1  *", InfixToPostfixConverter.ConvertFromInfixToPostfixExpression("3 * ( 2 + 1 ) "));

            Assert.AreNotEqual("6 2 - 3 ", InfixToPostfixConverter.ConvertFromInfixToPostfixExpression(" 6 - 2  + 3"));
            Assert.AreNotEqual("7 * 6 8 ^ 9 +", InfixToPostfixConverter.ConvertFromInfixToPostfixExpression("7 * 8 ^ 9 + 6"));
            Assert.AreNotEqual("7 8 9 10 * * +  11 +", InfixToPostfixConverter.ConvertFromInfixToPostfixExpression("7 * (8 + 9 * 10) + 11"));


        }

    }
}
