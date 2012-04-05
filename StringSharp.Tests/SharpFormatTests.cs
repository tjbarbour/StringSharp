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
    }
}
