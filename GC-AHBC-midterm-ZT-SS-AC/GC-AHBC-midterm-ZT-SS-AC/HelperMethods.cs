﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GC_AHBC_midterm_ZT_SS_AC
{
    public static class HelperMethods
    {
        public static double MakeChange(double amountTendered, double totalPrice)
        {
            return amountTendered - totalPrice;
        }

        public static bool TryAgain(string userInput)
        {
            if (userInput.Trim().ToLower() == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static List<Product> AddItemToOrder (int numberToOrder, List<Product> currentOrderList, Product product)
        {
            for (int i = 0; i < numberToOrder; i++)
            {
                currentOrderList.Add(product);
            }
            return currentOrderList;
        }
    }
}
