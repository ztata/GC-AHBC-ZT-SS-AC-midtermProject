using System;
using System.Collections.Generic;
using System.Text;
using GC_AHBC_midterm_ZT_SS_AC;
using Xunit;

namespace GC_AHBC_midterm_ZT_SS_AC.Tests.HelperMethodsTests
{
    public class MakeChangeTests
    {
        [Theory]
        [InlineData(500,100, 400)]
        [InlineData(50, 25, 25)]
        [InlineData(0, 0, 0)]
        [InlineData(-10, -10, 0)]
        public static void ProvideValidDoubleAndPrice_ReturnDifferenceOfTheTwo(double amountTendered, double totalPrice, double expectedValue)
        {
            //arrange

            //act
            double difference = HelperMethods.MakeChange(amountTendered, totalPrice);
            //assert
            Assert.Equal(expectedValue, difference);
        }
    }
}


























