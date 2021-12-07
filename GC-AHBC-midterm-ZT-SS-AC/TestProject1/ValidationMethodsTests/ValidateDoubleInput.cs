using System;
using System.Collections.Generic;
using System.Text;
using GC_AHBC_midterm_ZT_SS_AC;
using Xunit;

namespace GC_AHBC_midterm_ZT_SS_AC.Tests.ValidationMethodsTests
{
    public class ValidateDoubleInput
    {
        [Theory]
        [InlineData("5.7", true)]
        [InlineData("12.59", true)]
        [InlineData("-1.4", true)]
        [InlineData("0", true)]
        public static void ProvideValidDoubles_ReturnsTrue(string input, bool expectedReturn)
        {
            //arrange

            //act
            bool actualReturn = ValidationMethods.ValidateDoubleInput(input);
            //assert
            Assert.Equal(expectedReturn, actualReturn);
        }

        [Theory]
        [InlineData("These", false)]
        [InlineData("Are", false)]
        [InlineData("Not", false)]
        [InlineData("Doubles", false)]
        [InlineData(null, false)]
        public static void ProvideInvalidDoubles_ReturnsFalse(string input, bool expectedReturn)
        {
            //arrange

            //act
            bool actualReturn = ValidationMethods.ValidateDoubleInput(input);
            //assert
            Assert.Equal(expectedReturn, actualReturn);
        }
    }
}
