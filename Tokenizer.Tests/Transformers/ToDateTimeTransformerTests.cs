﻿using System;
using NUnit.Framework;

namespace Tokens.Transformers
{
    [TestFixture]
    public class ToDateTimeTransformerTests
    {
        private ToDateTimeTransformer @operator;

        [SetUp]
        public void SetUp()
        {
            @operator = new ToDateTimeTransformer();
        }

        [Test]
        public void TestParseDate()
        {
            var result =  @operator.CanTransform("2014-01-01", new [] { "yyyy-MM-dd" }, out var t);

            var dateTime = (DateTime) t;

            Assert.IsTrue(result);
            Assert.AreEqual(new DateTime(2014, 1, 1), dateTime);
            Assert.AreEqual(DateTimeKind.Unspecified, dateTime.Kind);
        }

        [Test]
        public void TestParseDateWithFormat()
        {
            var result = @operator.CanTransform("2 Mar 2012", new [] { "d MMM yyyy" }, out var t);
            var dateTime = (DateTime) t;

            Assert.IsTrue(result);
            Assert.AreEqual(new DateTime(2012, 3, 2), dateTime);
        }

        [Test]
        public void TestParseDateWithNoFormat()
        {
            var result = @operator.CanTransform("2012-05-06", null, out var t);
            var dateTime = (DateTime) t;

            Assert.IsTrue(result);
            Assert.AreEqual(new DateTime(2012, 5, 6), dateTime);
        }

        [Test]
        public void TestParseDateWithInvalidFormat()
        {
            var result = @operator.CanTransform("2012-05-06", new [] { "dd MMM yy" }, out var t);
            
            Assert.IsFalse(result);
            Assert.AreEqual("2012-05-06", t);
        }

        [Test]
        public void TestParseDateWithFormatList()
        {
            var result = @operator.CanTransform("2012-05-06", new [] { "dd MMM yy", "yyyy-MM-dd" }, out var t);
            var dateTime = (DateTime) t;

            Assert.IsTrue(result);
            Assert.AreEqual(new DateTime(2012, 5 ,6), dateTime);
        }

        [Test]
        public void TestParseDateWithEmptyValue()
        {
            var result = @operator.CanTransform(string.Empty, null, out var t);

            Assert.IsFalse(result);
            Assert.AreEqual(string.Empty, t);
        }

        [Test]
        public void TestParseDateWithNullValue()
        {
            var result = @operator.CanTransform(null, null, out var t);

            Assert.IsFalse(result);
            Assert.AreEqual(null, t);
        }

        [Test]
        public void TestParseDateWithUnixNewLine()
        {
            var result = @operator.CanTransform("2012-05-06\nHello", null, out var t);
            var dateTime = (DateTime) t;

            Assert.IsTrue(result);
            Assert.AreEqual(new DateTime(2012, 5, 6), t);
        }

        [Test]
        public void TestParseDateWithWindowsNewLine()
        {
            var result = @operator.CanTransform("2012-05-06\r\nHello", null, out var t);

            Assert.IsTrue(result);
            Assert.AreEqual(new DateTime(2012, 5, 6), t);
        }

        [Test]
        public void TestParseDateWithDayOrdinalAtStart()
        {
            var result = @operator.CanTransform("01st August 2001", new [] { "dd MMMM yyyy" }, out var t);
            var dateTime = (DateTime) t;

            Assert.IsTrue(result);
            Assert.AreEqual(new DateTime(2001, 8 , 1), dateTime);
        }

        [Test]
        public void TestParseDateWithDayOrdinalInMiddle()
        {
            var result = @operator.CanTransform("August 2nd 2001", new [] { "MMMM d yyyy" }, out var t);
            var dateTime = (DateTime) t;

            Assert.IsTrue(result);
            Assert.AreEqual(new DateTime(2001, 8 , 2), dateTime);
        }

        [Test]
        public void TestParseDateWithSpanishFullMonth()
        {
            var result = @operator.CanTransform("Agosto 2nd 2001", new [] { "MMMM d yyyy" }, out var t);
            var dateTime = (DateTime) t;

            Assert.IsTrue(result);
            Assert.AreEqual(new DateTime(2001, 8 , 2), dateTime);
        }

        [Test]
        public void TestParseDateWithSpanishMonthAbbreviation()
        {
            var result = @operator.CanTransform("16-abr-1997", new [] { "dd-MMM-yyyy" }, out var t);
            var dateTime = (DateTime) t;

            Assert.IsTrue(result);
            Assert.AreEqual(new DateTime(1997, 4 , 16), dateTime);
        }
    }
}