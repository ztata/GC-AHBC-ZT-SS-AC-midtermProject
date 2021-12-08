using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GC_AHBC_midterm_ZT_SS_AC.Tests.FileHelperTests
{
    public class BuildMenuListTests
    {
        // Happy path
        [Fact]
        public static void ProvideAddressPath_ReturnArrayOfProducts()
        {
            // Arrange
            string addressPath = @$"{Environment.CurrentDirectory}\TestFile.txt";
            Product[] productArray = new Product[3];

            // Act


            // Assert

        }
    }
}
