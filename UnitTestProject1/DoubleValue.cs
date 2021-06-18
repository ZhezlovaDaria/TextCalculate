using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreClasses;

namespace UnitTestProject1
{
	[TestClass]
	public class UT_DoubleValue
	{
		[TestMethod]
		public void Constr()
		{
			DoubleValue dv = new DoubleValue(4);
			Assert.AreEqual(4,dv.value);
		}

		[TestMethod]
		public void DToString()
		{
			DoubleValue dv = new DoubleValue(4);
			Assert.AreEqual("4", dv.value.ToString());
		}
	}
}
