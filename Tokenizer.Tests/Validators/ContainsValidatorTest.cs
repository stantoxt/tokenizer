﻿using NUnit.Framework;
using Tokens.Exceptions;

namespace Tokens.Validators
{
    [TestFixture]
    public class ContainsValidatorTest
    {
        private ContainsValidator validator;

        [SetUp]
        public void SetUp()
        {
            validator = new ContainsValidator();
        }

        [Test]
        public void TestValidateValueWhenTrue()
        {
            var result = validator.IsValid("hello world", "o wor");

            Assert.IsTrue(result);
        }

        [Test]
        public void TestValidateValueWhenFalse()
        {
            var result = validator.IsValid("hello world", "spoon");

            Assert.IsFalse(result);
        }

        [Test]
        public void TestValidateValueWhenMissingArgument()
        {
            Assert.Throws<TokenizerException>(() => validator.IsValid("hello world"));
        }

        [Test]
        public void TestValidateValueWhenNull()
        {
            var result = validator.IsValid(null);

            Assert.IsFalse(result);
        }

        [Test]
        public void TestValidateValueWhenEmpty()
        {
            var result = validator.IsValid(string.Empty);

            Assert.IsFalse(result);
        }
    }
}
