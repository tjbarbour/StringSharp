using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringSharp;

namespace StringSharp.Tests
{
    [TestClass]
    public class SharpFormatTests
    {
        public void SFTest(string sharpFormat, string expected, params object[] args)
        {
            string formatted = sharpFormat.SFormat(args);
            Assert.AreEqual(expected, formatted);
        }

        [TestMethod]
        public void ShouldLeaveConstantStringAlone()
        {
            SFTest("Hello StringSharp!","Hello StringSharp!");
        }

        [TestMethod]
        public void EmptyStaysEmpty()
        {
            SFTest("", "");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullThrowsArgumentException()
        {
            string original = null;
            original.SFormat();
        }

        [TestMethod]
        public void EscapeSharp()
        {
            SFTest("We're ##1!", "We're #1!");
        }

        [TestMethod]
        public void FormatASingleArgument()
        {
            SFTest("There are # weeks in the year", "There are 52 weeks in the year", 52);
        }

        [TestMethod]
        public void FormatASingleArgumentAtHead()
        {
            SFTest("# world!", "Hello world!", "Hello"); 
        }

        [TestMethod]
        public void FormatASingleArgumentAtFoot()
        {
            SFTest("Hello #", "Hello world!", "world!");
        }
    }
}
