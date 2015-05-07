using System;
using System.Text.RegularExpressions;

namespace KiryTools.Validations
{
    public static class StringValidationsAdittions
    {
        public static bool IsEmail(this string email)
        {
            const string expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (!Regex.IsMatch(email, expresion)) return false;
            var result = Regex.Replace(email, expresion, String.Empty).Length == 0;
            return result;
        }
        public static bool IsMatch(this string email,string exp)
        {
            if (!Regex.IsMatch(email, exp)) return false;
            var result = Regex.Replace(email, exp, String.Empty).Length == 0;
            return result;
        }
        public static bool IsInteger(this string number)
        {
            int result;
            return int.TryParse(number, out result);
        }
    }
}
