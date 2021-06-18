using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreClasses;

namespace UnitTestProject1
{
	[TestClass]
	public class UT_ConstValue
	{
		[TestMethod]
		public void GetValue()
		{
			ConstExpression ce = new ConstExpression(new DoubleValue(3));
			Assert.AreEqual("3", ce.GetValue().ToString());
		}
	}
}
