using System;
using System.Collections.Generic;
using System.Text;
using GC_AHBC_midterm_ZT_SS_AC;
using Xunit;

namespace GC_AHBC_midterm_ZT_SS_AC.Tests.BillingRegexMethodsTests
{
    public class ValidateCardNumberTests
    {
        [Theory]
        [InlineData("1234-1234-1234-1234", true)]
        [InlineData("1111-1111-1111-1111", true)]
        [InlineData("0000-0000-0000-0000", true)]
        [InlineData("9999-9999-9999-9999", true)]
        [InlineData("1256-2345-5678-8989", true)]
        public static void ProvideValidCardNumber_ReturnsTrue(string cardNumber, bool expectedResult)
        {
            //arrange

            //act
            bool actualReturn = BillingRegexMethods.ValidateCardNumber(cardNumber);
            //assert
            Assert.Equal(expectedResult, actualReturn);
        }

        [Theory]
        [InlineData("1234123412341234", false)]
        [InlineData("1111-1111-1111", false)]
        [InlineData("0000-0000-00000000", false)]
        [InlineData("9999-9999-9999-99", false)]
        [InlineData("12546-24345-45678-48989", false)]
        public static void ProvideInvalidCardNumber_ReturnsFalse(string cardNumber, bool expectedResult)
        {
            //arrange

            //act
            bool actualReturn = BillingRegexMethods.ValidateCardNumber(cardNumber);
            //assert
            Assert.Equal(expectedResult, actualReturn);
        }
    }

}
