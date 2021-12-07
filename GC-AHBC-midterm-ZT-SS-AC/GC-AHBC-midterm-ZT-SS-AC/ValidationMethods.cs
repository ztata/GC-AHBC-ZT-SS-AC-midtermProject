using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GC_AHBC_midterm_ZT_SS_AC
{
    public static class ValidationMethods
    {
        public static bool ValidateIntInput (string userInput)
        {
            if (string.IsNullOrEmpty(userInput) == true)
            {
                return false;
            }
            try
            {
                int.Parse(userInput);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static bool ValidateDoubleInput (string userInput)
        {
            if (string.IsNullOrEmpty(userInput) == true)
            {
                return false;
            }
            try
            {
                double.Parse(userInput);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }






    }
}
