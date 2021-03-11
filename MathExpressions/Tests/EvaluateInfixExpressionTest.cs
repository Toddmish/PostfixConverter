using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExpressions
{
    class EvaluateInfixExpressionTest
    {
        [Test]
        public void ComputeTest()
        {
            Assert.AreEqual(391, EvaluateInfixExpression.Compute("100.5 + 300.5 - 100 * 10 / 100"));

            Assert.AreEqual(7, EvaluateInfixExpression.Compute(" 1 + 2  * 3"));
            Assert.AreEqual(5, EvaluateInfixExpression.Compute("1 * 2 + 3"));
            Assert.AreEqual(9, EvaluateInfixExpression.Compute("3 * ( 2 + 1 ) "));

            Assert.AreEqual(7, EvaluateInfixExpression.Compute(" 6 - 2  + 3"));
            Assert.AreEqual(939524102, EvaluateInfixExpression.Compute("7 * 8 ^ 9 + 6"));
            Assert.AreEqual(697, EvaluateInfixExpression.Compute("7 * (8 + 9 * 10) + 11"));

            Assert.AreEqual(701, EvaluateInfixExpression.Compute("2^2 + 7 * (8 + 9 * 10) + 11"));
            Assert.AreEqual(705, EvaluateInfixExpression.Compute("2^2 + 7 * (8 + 9 * 10) + 11 + 2^2"));
            Assert.AreEqual(697, EvaluateInfixExpression.Compute("2^2 + 7 * (8 + 9 * 10) + 11 - 2^2"));

            Assert.AreNotEqual(701, EvaluateInfixExpression.Compute("2^2 + 7 * (8 + 9 * 10) + 11 - 2^2"));

        }
    }
}
