using System;
using System.Collections.Generic;
using System.Text;
using GC_AHBC_midterm_ZT_SS_AC;
using Xunit;

namespace GC_AHBC_midterm_ZT_SS_AC.Tests.HelperMethodsTests
{
    public class TryAgainTests
    {
        [Theory]
        [InlineData("Y", true)]
        [InlineData("Y ", true)]
        [InlineData("y", true)]
        [InlineData("y ", true)]
        public static void ProvideYAsStringInput_ReturnTrue(string userInput, bool expectedValue)
        {
            //arrange

            //act
            bool returnedValue = HelperMethods.TryAgain(userInput);
            //assert
            Assert.Equal(expectedValue, returnedValue);
        }

        [Theory]
        [InlineData("n",false)]
        [InlineData("no",false)]
        [InlineData("123",false)]
        [InlineData(null,false)]
        public static void ProvideAnythingButYAsStringInput_ReturnFalse(string userinput, bool expectedValue)
        {
            //arange

            //act
            bool returnedValue = HelperMethods.TryAgain(userinput);
            //assert
            Assert.Equal(expectedValue, returnedValue);
        }



    }
}
