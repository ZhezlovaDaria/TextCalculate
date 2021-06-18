using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreClasses;

namespace UnitTestProject1
{
	[TestClass]
	public class UT_Multi
	{
		[TestMethod]
	public void Name()
	{
		Multiplication m = new Multiplication();
		string name = m.Name;
		Assert.AreEqual("*", name);
	}

	[TestMethod]
	public void Priority()
	{
			Multiplication m = new Multiplication();
		int prior = m.Priority;
		Assert.AreEqual(50, prior);
	}

	[TestMethod]
	public void NArgs()
	{
			Multiplication m = new Multiplication();
		int args = m.NArgs;
		Assert.AreEqual(2, args);
	}

	[TestMethod]
	public void Make()
	{
			Multiplication m = new Multiplication();
		IExpression[] ie = new IExpression[2] { new ConstExpression(new DoubleValue(2)), new ConstExpression(new DoubleValue(3)) };
			MultiplicationExpression sum = (MultiplicationExpression)m.Make(ie);
		DoubleValue result = (DoubleValue)sum.GetValue();
		Assert.AreEqual(6, result.value, 1e-9);
	}
}
}
