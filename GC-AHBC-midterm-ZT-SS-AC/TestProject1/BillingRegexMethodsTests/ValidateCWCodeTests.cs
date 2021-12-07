using System;
using System.Collections.Generic;
using System.Text;
using GC_AHBC_midterm_ZT_SS_AC;
using Xunit;

namespace GC_AHBC_midterm_ZT_SS_AC.Tests.BillingRegexMethodsTests
{
    public class ValidateCWCodeTests
    {
        [Theory]
        [InlineData("123", true)]
        [InlineData("568", true)]
        [InlineData("000", true)]
        [InlineData("999", true)]
        [InlineData("156", true)]
        public static void ProvideValidCWNumber_ReturnsTrue(string cwNumber, bool expectedResult)
        {
            //arrange

            //act
            bool actualReturn = BillingRegexMethods.ValidateCWCode(cwNumber);
            //assert
            Assert.Equal(expectedResult, actualReturn);
        }

        [Theory]
        [InlineData("1", false)]
        [InlineData("12", false)]
        [InlineData("1234", false)]
        [InlineData("12345", false)]
        [InlineData("-123456", false)]
        public static void ProvideInvalidCWNumber_ReturnsFalse(string cwNumber, bool expectedResult)
        {
            //arrange

            //act
            bool actualReturn = BillingRegexMethods.ValidateCWCode(cwNumber);
            //assert
            Assert.Equal(expectedResult, actualReturn);
        }


    }

}
