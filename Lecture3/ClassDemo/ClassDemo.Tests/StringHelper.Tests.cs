using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demo.Helpers;

namespace ClassDemo.Tests;

[TestClass]
public class StringHelperTests
{
    [TestMethod]
    public void Given_YouKilledMyFather_SuffixDotDotDot()
    {
        // Arrange
        string text = "You killed my father";
        
        // Assert
        Assert.AreEqual("You killed my father...", text.AppendEllipses());
    }

    [TestMethod]
    public void OnStaticCallGiven_YouKilledMyFather_SuffixDotDotDot()
    {
        // Arrange
        string text = "You killed my father";

        // Assert
        Assert.AreEqual("You killed my father...",
            StringHelper.AppendEllipses(text));
    }
}
