using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreClasses;

namespace UnitTestProject1
{
	[TestClass]
	public class DivExpTest
	{
		[TestMethod]
		public void TestNormal()
		{ 
			ConstExpression arg1 = new ConstExpression(new DoubleValue(4));
			ConstExpression arg2 = new ConstExpression(new DoubleValue(2));
			IExpression[] ie = new IExpression[2] { arg1, arg2 };
			DivideExpression mul = new DivideExpression();
			mul.StartExp(ie);
			DoubleValue result = (DoubleValue)mul.GetValue();
			Assert.AreEqual(2, result.value, 1e-9);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidCastException))]
		public void TestTypeError()
		{
			ConstExpression arg1 = new ConstExpression(new DoubleValue(2));
			ConstExpression arg2 = new ConstExpression(new TupleValue(new DoubleValue(2), new DoubleValue(2)));
			IExpression[] ie = new IExpression[2] { arg1, arg2 };
			DivideExpression mul = new DivideExpression();
			mul.StartExp(ie);
			DoubleValue result = (DoubleValue)mul.GetValue();
		}
	}
}
