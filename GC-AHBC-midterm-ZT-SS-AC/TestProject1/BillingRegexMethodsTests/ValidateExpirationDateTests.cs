using System;
using System.Collections.Generic;
using System.Text;
using GC_AHBC_midterm_ZT_SS_AC;
using Xunit;

namespace GC_AHBC_midterm_ZT_SS_AC.Tests.BillingRegexMethodsTests
{
    public class ValidateExpirationDateTests
    {
        [Theory]
        [InlineData("01/2028", true)]
        [InlineData("02/2022", true)]
        [InlineData("10/2025", true)]
        [InlineData("12/2023", true)]
        [InlineData("08/2027", true)]
        public static void ProvideValidExpirationDate_ReturnsTrue(string expirationDate, bool expectedResult)
        {
            //arrange

            //act
            bool actualReturn = BillingRegexMethods.ValidateExpirationDate(expirationDate);
            //assert
            Assert.Equal(expectedResult, actualReturn);
        }

        [Theory]
        [InlineData("01/1999", false)]
        [InlineData("32/2021", false)]
        [InlineData("00/2026", false)]
        [InlineData("012/2026", false)]
        [InlineData("10/22332", false)]
        public static void ProvideInvalidExpirationDate_ReturnsFalse(string expirationDate, bool expectedResult)
        {
            //arrange

            //act
            bool actualReturn = BillingRegexMethods.ValidateExpirationDate(expirationDate);
            //assert
            Assert.Equal(expectedResult, actualReturn);
        }

    }

}
