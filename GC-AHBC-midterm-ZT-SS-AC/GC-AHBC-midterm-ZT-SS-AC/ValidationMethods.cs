using System;
using System.Collections.Generic;
using System.Text;

namespace GC_AHBC_midterm_ZT_SS_AC
{
    public static class ValidationMethods
    {
        public static bool ValidateIntInput (string userInput)
        {
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
