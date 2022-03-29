using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FormaulaTree.Api.Services;
using FormaulaTree.Api.Models;

namespace FormulaTree.Tests;

[TestClass]
public class ExpressionEvaluatorTests
{
    [DataTestMethod]
    [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
    public void TestConvertToTree(string input, double expected)
    {
        var evaulator = new ExpressionEvaluator();

        var result = evaulator.ConvertToTree(input); 
        Assert.IsTrue(result != null);
        Assert.AreEqual(expected, result?.Calculate());
    }
    public static IEnumerable<object[]> GetData()
    {
        var lines = File.ReadAllLines("TestData.txt");

        foreach(var line in lines)
        {
            var parts = line.Split(new char[] {','});
            yield return new object[] {parts[0], Convert.ToDouble(parts[1])};
        }
    }
}