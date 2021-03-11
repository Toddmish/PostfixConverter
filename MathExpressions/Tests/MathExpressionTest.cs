using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExpressions
{
    [TestFixture]
    class MathExpressionTest
    {
        [Test]
        public void IsOperatorTest()
        {
            Assert.AreEqual(true, MathExpression.IsOperator("+"));
            Assert.AreEqual(true, MathExpression.IsOperator("-"));
            Assert.AreEqual(true, MathExpression.IsOperator("*"));
            Assert.AreEqual(true, MathExpression.IsOperator("/"));
            Assert.AreEqual(true, MathExpression.IsOperator("^"));
            Assert.AreEqual(true, MathExpression.IsOperator("("));
            Assert.AreEqual(true, MathExpression.IsOperator(")"));

            Assert.AreEqual(false, MathExpression.IsOperator("^/"));
            Assert.AreEqual(false, MathExpression.IsOperator(""));
            Assert.AreEqual(false, MathExpression.IsOperator("."));
        }
    }
}
