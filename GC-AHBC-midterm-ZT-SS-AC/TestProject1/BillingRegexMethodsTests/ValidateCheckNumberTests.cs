using System;
using System.Collections.Generic;
using System.Text;
using GC_AHBC_midterm_ZT_SS_AC;
using Xunit;

namespace GC_AHBC_midterm_ZT_SS_AC.Tests.BillingRegexMethodsTests
{
    public class ValidateCheckNumberTests
    {
        [Theory]
        [InlineData("1234", true)]
        [InlineData("5678", true)]
        [InlineData("0000", true)]
        [InlineData("9999", true)]
        [InlineData("1256", true)]
        public static void ProvideValidCheckNumber_ReturnsTrue(string checkNumber, bool expectedResult)
        {
            //arrange

            //act
            bool actualReturn = BillingRegexMethods.ValidateCheckNumber(checkNumber);
            //assert
            Assert.Equal(expectedResult, actualReturn);
        }

        [Theory]
        [InlineData("1", false)]
        [InlineData("12", false)]
        [InlineData("123", false)]
        [InlineData("12345", false)]
        [InlineData("123456", false)]
        public static void ProvideInvalidCheckNumber_ReturnsFalse(string checkNumber, bool expectedResult)
        {
            //arrange

            //act
            bool actualReturn = BillingRegexMethods.ValidateCheckNumber(checkNumber);
            //assert
            Assert.Equal(expectedResult, actualReturn);
        }
    }
}
