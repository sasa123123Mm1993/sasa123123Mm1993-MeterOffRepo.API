using System.Globalization;
using System.Text.RegularExpressions;

namespace GPICardCore
{
    public static class Validate
    {
        public static int MaximumMeterNumberLength { get; private set; } = 8;
                 
        public static bool IsValidDateFormat(string dateString)
        {
            if (string.IsNullOrEmpty(dateString))
            {
                return false;
            }

            DateTime date;
            string format = "dd-MM-yyyy";
            bool isValid = DateTime.TryParseExact(
                dateString,
                format,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out date
            );

            return isValid;
        }
        public static bool IsValidDateList(List<string> dateStringList)
        {
            // Check if the list is null or empty
            if (dateStringList == null || dateStringList.Count == 0)
            {
                return false;
            }

            string format = "dd-MM-yyyy";

            foreach (var dateString in dateStringList)
            {
                if (string.IsNullOrEmpty(dateString))
                {
                    return false;
                }

                DateTime date;
                bool isValid = DateTime.TryParseExact(
                    dateString,
                    format,
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out date
                );

                if (!isValid)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsNotNullAndNonNegative<T>(T? number) where T : struct, IComparable
        {
            if (number.HasValue)
            {
                return (number.Value.CompareTo(default(T)) >= 0) ;
            }
            return false;
        }

        public static bool ValidateBillingDay(string input)
        {
            // Define the regex pattern for "dd HH:mm"
            string pattern = @"^(0[1-9]|[12][0-9]|3[01]) ([01][0-9]|2[0-3]):[0-5][0-9]$";

            // Check if the input matches the pattern
            if (!Regex.IsMatch(input, pattern))
            {
                return false;
            }

            // Split the input to validate each part separately
            string[] parts = input.Split(' ');
            string dayPart = parts[0];
            string timePart = parts[1];

            // Validate the day part (already partially validated by the regex)
            if (!int.TryParse(dayPart, out int day) || day < 1 || day > 31)
            {
                return false;
            }

            // Validate the time part (already partially validated by the regex)
            string[] timeParts = timePart.Split(':');
            if (!int.TryParse(timeParts[0], out int hours) || !int.TryParse(timeParts[1], out int minutes))
            {
                return false;
            }

            return true;
        }

        public static bool ValidMeterNo(string input)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(input)) return false;
                return (input.Length == MaximumMeterNumberLength  && input.All(char.IsDigit) );
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
