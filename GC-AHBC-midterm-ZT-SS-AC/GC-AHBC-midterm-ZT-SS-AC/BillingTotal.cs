using System;
using System.Collections.Generic;
using System.Text;

namespace GC_AHBC_midterm_ZT_SS_AC
{
    public static class BillingTotal
    {

        // Loops through the currentOrderList and adds each item's price to the subtotal and returns the subtotal
        public static double SubTotal(List<Product> currentOrderList)
        {
            // Throw an exception if the currentOrderList is empty
            if (currentOrderList.Count == 0)
            {
                throw new ArgumentNullException();
            }
            double subtotal = 0.0;

            // Add the price of each item in the current order list to the subtotal
            foreach (var item in currentOrderList)
            {
                subtotal = Math.Round(subtotal + item.Price, 2, MidpointRounding.AwayFromZero);
            }

            return subtotal;
        }

        // Returns the total sales tax of the subtotal when the subtotal and sales tax (as a decimal) are given
        public static double SalesTax(double subtotal, double salesTaxPercent)
        {
            double subtotalSalesTax = Math.Round(subtotal * salesTaxPercent, 2, MidpointRounding.AwayFromZero);

            return subtotalSalesTax;
        }

        // Returns the grand total which is the subtotal plus the total sales tax
        public static double GrandTotal(double subtotal, double subtotalSalesTax)
        {
            double grandTotal = Math.Round(subtotal + subtotalSalesTax, 2, MidpointRounding.AwayFromZero);

            return grandTotal;
        }
    }
}
