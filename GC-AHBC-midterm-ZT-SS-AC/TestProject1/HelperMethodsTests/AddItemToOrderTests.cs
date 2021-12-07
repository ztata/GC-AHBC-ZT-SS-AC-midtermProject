using System;
using System.Collections.Generic;
using System.Text;
using GC_AHBC_midterm_ZT_SS_AC;
using Xunit;

namespace GC_AHBC_midterm_ZT_SS_AC.Tests.HelperMethodsTests
{
    public class AddItemToOrderTests
    {
        [Fact]
        public static void ProvideValidProductObjectAndInt_AddProductToListIntNumberOfTimes()
        {
            //arrange
            int numberToOrder = 3;
            Product itemToAdd = new Product();
            List<Product> currentOrderList = new List<Product>();
            List<Product> expectedListResult = new List<Product>() { itemToAdd, itemToAdd, itemToAdd};
            //act
            currentOrderList = HelperMethods.AddItemToOrder(numberToOrder, currentOrderList, itemToAdd);
            //assert
            Assert.Equal(expectedListResult, currentOrderList);
        }

        [Fact]
        public static void ProvideValidProductObjectAndInvalidInt_ThrowsArgumentException()
        {
            //arrange
            int numberToOrder = -1;
            Product itemToAdd = new Product();
            List<Product> currentOrderList = new List<Product>();

            //act
            Action action = () => HelperMethods.AddItemToOrder(numberToOrder, currentOrderList, itemToAdd);
            //assert
            Assert.Throws<ArgumentException>(action);
        }




    }
}
