using System;
using System.Text.RegularExpressions;

namespace MomsRapportApp.Validations
{
    public interface IValidationRule<T>
    {
        string Message { get; set; }
        bool Check(T value);
    }

    public class IsNotNullOrWhiteSpaceRule : IValidationRule<string>
    {
        public string Message { get; set; }

        public bool Check(string value)
        {
            if (value == null)
                return false;

            return !string.IsNullOrWhiteSpace(value);
        }
    }

    public class EmailRule : IValidationRule<string>
    {
        public string Message { get; set; }

        public bool Check(string value)
        {
            if (value == null)
                return false;

            string pattern = "([\\w]+)@([\\w]+)(\\.(\\w){2,3})";
            Match match = Regex.Match(value, pattern);
            return match.Success;
        }
    }

    public class OnlyNumbersRule : IValidationRule<string>
    {
        public string Message { get; set; }

        public bool Check(string value)
        {
            double result;
            return Double.TryParse(value, out result);
        }
    }
}
