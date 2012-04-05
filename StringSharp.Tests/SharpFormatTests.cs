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
        [TestMethod]
        public void ShouldLeaveConstantStringAlone()
        {
            string original = "Hello StringSharp!";
            string formatted = original.SFormat();
            Assert.AreEqual(original, formatted);
        }

        [TestMethod]
        public void EmptyStaysEmpty()
        {
            string original = "";
            string formatted = original.SFormat();
            Assert.AreEqual(original, formatted);
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
            string original = "We're ##1!";
            string formatted = original.SFormat();
            string expected = "We're #1!";
            Assert.AreEqual(expected, formatted);
        }
    }
}
