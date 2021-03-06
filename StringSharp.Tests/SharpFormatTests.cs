﻿using System;
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
            string formatted = sharpFormat.SharpFormat(args);
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
        [ExpectedException(typeof(NullReferenceException))]
        public void NullThrowsException()
        {
            string original = null;
            original.SharpFormat();
        }

        [TestMethod]
        public void EscapeSharp()
        {
            SFTest("We're ##1!", "We're #1!");
        }

        [TestMethod]
        public void EscapeOverload()
        {
            SFTest("######", "###");
        }

        [TestMethod]
        public void FormatSingle()
        {
            SFTest("There are # weeks in the year", "There are 52 weeks in the year", 52);
        }

        [TestMethod]
        public void FormatSingleAtHead()
        {
            SFTest("# world!", "Hello world!", "Hello"); 
        }

        [TestMethod]
        public void FormatSingleAtFoot()
        {
            SFTest("Hello #", "Hello world!", "world!");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void FormatSingleWithotArgsShouldThrowException()
        {
            "Testing # Testing".SharpFormat();
        }

        [TestMethod]
        public void FormatMultiple()
        {
            SFTest("One #, Two #, Three #.", "One 1, Two 2, Three 3.", 1,2,3);
        }

        [TestMethod]
        public void RepeatPreviousArgument()
        {
            SFTest(
                "# is my name, nice to meet you #, said #0",
                "Joe is my name, nice to meet you Earl, said Joe",
                "Joe", "Earl");
        }

        [TestMethod]
        public void RepeatMultplePreviousMultipleTimes()
        {
            SFTest(
                "# first # second #0 first again # third #1 second again #0 first again # fourth #2 third again #1 second again",
                "101 first 202 second 101 first again 303 third 202 second again 101 first again 404 fourth 303 third again 202 second again",
                101, 202, 303, 404);
        }

        [TestMethod]
        public void CombineEscapeAndArguments()
        {
            SFTest("C## is ###!", "C# is #1!", 1);
        }
    }
}
