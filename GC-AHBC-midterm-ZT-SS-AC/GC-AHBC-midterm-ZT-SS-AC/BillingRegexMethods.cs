using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace GC_AHBC_midterm_ZT_SS_AC
{
    public static class BillingRegexMethods
    {
          public static bool ValidateCheckNumber (string checkNumber)
        {
            string pattern = "^[0-9]{4}$";
            Regex regex = new Regex(pattern);
            bool validCheckNumber = regex.IsMatch(checkNumber);
            return validCheckNumber;
        }   

        public static bool ValidateCardNumber (string creditCardNumber)
        {
            string pattern = "^[0-9]{4}-[0-9]{4}-[0-9]{4}-[0-9]{4}$";
            Regex regex = new Regex(pattern);
            bool validCardNumber = regex.IsMatch(creditCardNumber);
            return validCardNumber;
        }

        public static bool ValidateExpirationDate(string expirationDate)
        {
            //this will not catch all bad months 
            string pattern = @"^[0-1][0-9]\/[2][0][2][1-9]$";
            Regex regex = new Regex(pattern);
            bool validExpirationDate = regex.IsMatch(expirationDate);
            return validExpirationDate;
        }

        public static bool ValidateCWCode(string cwCode)
        {
            string pattern = "^[0-9]{3}$";
            Regex regex = new Regex(pattern);
            bool validCWCode = regex.IsMatch(cwCode);
            return validCWCode;
        }
    }
}
