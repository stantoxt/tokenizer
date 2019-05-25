﻿using NUnit.Framework;

namespace Tokens.Validators
{
    [TestFixture]
    public class IsEmailValidatorTest
    {
        private IsEmailValidator validator;

        [SetUp]
        public void SetUp()
        {
            validator = new IsEmailValidator();
        }

        [Test]
        public void TestValidateValueWhenValid()
        {
            var result = validator.IsValid("hello@example.com");

            Assert.IsTrue(result);
        }

        [Test]
        public void TestValidateValueWhenInvalid()
        {
            var result = validator.IsValid("hello world");

            Assert.IsFalse(result);
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
