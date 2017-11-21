using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace InputValidation
{
    public class Validation
    {

        public static bool ValidName(string inputName)
        {
            string name = "[A-Za-z]+";
            string whitespace = @"\s";
            string pattern = "^(" + name + whitespace + "*)+$";

            return Regex.IsMatch(inputName, pattern);
        }

        public static bool ValidPhone(string inputPhone)
        {
            string firstPart = @"((\(\d{3}\)?)|(\d{3}-))?";
            string secondPart = @"\d{3}-";
            string thirdPart = @"\d{4}";
            string pattern = "^" + firstPart + secondPart + thirdPart + "$";

            return Regex.IsMatch(inputPhone, pattern);
        }

        public static bool ValidEmail(string inputEmail)
        {
            string userName = @"[0-9a-z\.-]+";
            string domain = @"([0-9a-z-] +\.)+";
            string tld = "[a-z]{2,4}";
            string pattern = "^" + userName + "@" + domain + tld + "$";
            string patternGood = @"^[0-9a-z\.-]+@([0-9a-z-]+\.)+[a-z]{2,4}$";
            return Regex.IsMatch(inputEmail, patternGood);
        }

        public static string ReformatPhone(string input)
        {
            Match match = Regex.Match(input, @"^\(?(\d{3})\)?[\s\-]?(\d{3})\-?(\d{4})$");

            return String.Format("({0}) {1}-{2}", match.Groups[1], match.Groups[2], match.Groups[3]);
        }
    }
}
