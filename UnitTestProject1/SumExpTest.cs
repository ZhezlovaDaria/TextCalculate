using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreClasses;

namespace UnitTestProject1
{
    [TestClass]
    public class SumExpTest
    {
        [TestMethod]
        public void TestNormal()
        {
			ConstExpression arg1 = new ConstExpression(new DoubleValue(2));
			ConstExpression arg2 = new ConstExpression(new DoubleValue(3));
			IExpression[] ie = new IExpression[2] { arg1, arg2 };
			SumExpression sum = new SumExpression();
			sum.StartExp(ie);
			DoubleValue result = (DoubleValue)sum.GetValue();
			Assert.AreEqual(5, result.value, 1e-9);
		}

        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))] 
        public void TestTypeError()
        {
			ConstExpression arg1 = new ConstExpression(new DoubleValue(2));
			ConstExpression arg2 = new ConstExpression(new TupleValue(new DoubleValue(2), new DoubleValue(2)));
			IExpression[] ie = new IExpression[2] { arg1, arg2 };
			SumExpression sum = new SumExpression();
			sum.StartExp(ie);
			DoubleValue result = (DoubleValue)sum.GetValue();
		}

    }
}
