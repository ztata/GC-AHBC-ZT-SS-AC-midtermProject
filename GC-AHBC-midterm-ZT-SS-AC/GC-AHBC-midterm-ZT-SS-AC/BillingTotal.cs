using System;
using System.Collections.Generic;
using System.Text;

namespace GC_AHBC_midterm_ZT_SS_AC
{
    public class BillingTotal
    {

        // Loops through the currentOrderList and adds each item's price to the subtotal and returns the subtotal
        public double SubTotal(ImenuItem currentOrderList)
        {
            double subtotal = 0.0d;

            foreach (var item in currentOrderList)
            {
                subtotal = subtotal + item.Price;
            }

            return subtotal;
        }

        // Returns the total sales tax of the subtotal when the subtotal and sales tax (as a decimal) are given
        public double SalesTax(double subtotal, double salesTaxPercent)
        {
            double subtotalSalesTax = subtotal * salesTaxPercent;

            return subtotalSalesTax;
        }

        public double GrandTotal(double subtotal, double subtotalSalesTax)
        {
            double grandTotal = subtotal + subtotalSalesTax;

            return grandTotal;
        }
    }
}
