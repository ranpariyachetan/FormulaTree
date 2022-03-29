using Microsoft.VisualStudio.TestTools.UnitTesting;
using FormaulaTree.Api.Services;
using FormaulaTree.Api.Models;

namespace FormulaTree.Tests;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
        var evaulator = new ExpressionEvaluator();

        var input = "3 + 4";

        var result = evaulator.ConvertToTree(input); 
        Assert.IsTrue(result != null);
        Assert.AreEqual(7, result?.Calculate());
    }
}