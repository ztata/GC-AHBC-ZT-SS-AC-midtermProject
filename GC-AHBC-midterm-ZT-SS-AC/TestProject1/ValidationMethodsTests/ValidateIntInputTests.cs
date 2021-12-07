using System;
using System.Collections.Generic;
using System.Text;
using GC_AHBC_midterm_ZT_SS_AC;
using Xunit;

namespace GC_AHBC_midterm_ZT_SS_AC.Tests.ValidationMethodsTests

{
    public class ValidateIntInputTests
    {
        [Theory]
        [InlineData("5", true)]
        [InlineData("12", true)]
        [InlineData("-1", true)]
        [InlineData("0", true)]
        public static void ProvideValidIntegers_ReturnsTrue(string input, bool expectedReturn)
        {
            //arrange

            //act
            bool actualReturn = ValidationMethods.ValidateIntInput(input);
            //assert
            Assert.Equal(expectedReturn, actualReturn);
        }

        [Theory]
        [InlineData("These", false)]
        [InlineData("Are", false)]
        [InlineData("Not", false)]
        [InlineData("Integers", false)]
        [InlineData(null, false)]
        [InlineData("12.5", false)]
        public static void ProvideInvalidIntegers_ReturnsFalse(string input, bool expectedReturn)
        {
            //arrange

            //act
            bool actualReturn = ValidationMethods.ValidateIntInput(input);
            //assert
            Assert.Equal(expectedReturn, actualReturn);
        }

    }
}
