using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GC_AHBC_midterm_ZT_SS_AC.Tests.BillingTotalMethodsTests
{
    public class SubtotalTests
    {
        // Happy path
        [Fact]
        public static void ProvideCurrentOrderList_ReturnSubtotal()
        {
            // Arrange
            List<Product> currentOrderList = new List<Product>();
            Product product1 = new Product();
            product1.Name = "Caffe Americano";
            product1.Price = 3.95;
            product1.Category = "Hot Coffee";
            product1.Description = "Water, Brewed Espresso";

            Product product2 = new Product();
            product2.Name = "Caffe Americano";
            product2.Price = 3.95;
            product2.Category = "Hot Coffee";
            product2.Description = "Water, Brewed Espresso";

            currentOrderList.Add(product1);
            currentOrderList.Add(product2);

            // Act
            double returnValue = BillingTotal.SubTotal(currentOrderList);

            // Assert
            Assert.Equal(7.90, returnValue);
        }

        // Unhappy path
        [Fact]
        public static void ProvideEmptyCurrentOrderList_ThrowsArgumentNullException()
        {
            // Arrange
            List<Product> currentOrderList = new List<Product>();

            // Act
            Action action = () => BillingTotal.SubTotal(currentOrderList);

            // Assert
            Assert.Throws<ArgumentNullException>(action);
        }

        // Happy path
        [Fact]
        public static void ProvideCurrentOrderList_ReturnSalesTax()
        {
            // Arrange
            List<Product> currentOrderList = new List<Product>();
            Product product1 = new Product();
            product1.Name = "Caffe Americano";
            product1.Price = 3.95;
            product1.Category = "Hot Coffee";
            product1.Description = "Water, Brewed Espresso";

            Product product2 = new Product();
            product2.Name = "Caffe Americano";
            product2.Price = 3.95;
            product2.Category = "Hot Coffee";
            product2.Description = "Water, Brewed Espresso";

            currentOrderList.Add(product1);
            currentOrderList.Add(product2);

            // Act
            double subtotal = BillingTotal.SubTotal(currentOrderList);
            double returnValue = BillingTotal.SalesTax(subtotal, .06);

            // Assert
            Assert.Equal(0.47, returnValue);
        }

        // Happy path
        [Fact]
        public static void ProvideCurrentOrderList_ReturnGrandTotal()
        {
            // Arrange
            List<Product> currentOrderList = new List<Product>();
            Product product1 = new Product();
            product1.Name = "Caffe Americano";
            product1.Price = 3.95;
            product1.Category = "Hot Coffee";
            product1.Description = "Water, Brewed Espresso";

            Product product2 = new Product();
            product2.Name = "Caffe Americano";
            product2.Price = 3.95;
            product2.Category = "Hot Coffee";
            product2.Description = "Water, Brewed Espresso";

            currentOrderList.Add(product1);
            currentOrderList.Add(product2);

            // Act
            double subtotal = BillingTotal.SubTotal(currentOrderList);
            double subtotalSalesTax = BillingTotal.SalesTax(subtotal, .06);
            double returnValue = BillingTotal.GrandTotal(subtotal, subtotalSalesTax);

            // Assert
            Assert.Equal(8.37, returnValue);
        }

    }
}
