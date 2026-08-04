using System.Globalization;

namespace Roznama.Common.Helpers
{
    public static class DateHelper
    {
        private static readonly string[] AcceptFormats =
        {
            "dd/MM/yyyy",
            "MM/dd/yyyy",
            "yyyy-MM-dd",
            "dd-MM-yyyy"
        };

        public static DateTime? Parse(string? input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return null;

            if (DateTime.TryParseExact(input, AcceptFormats, CultureInfo.InvariantCulture,
                DateTimeStyles.None, out var result))
            {
                return result;
            }

            return null;
        }

        public static string ToDisplay(DateTime? date)
        {
            return date?.ToString("dd/MM/yyyy") ?? "";
        }
    }
}