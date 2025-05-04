using System.Text.Json;
using System.Xml.Linq;

namespace CardServConvert.Validator
{
    public static class Tools
    {

        public static bool IsValidXML(string xml)
        {
            if (string.IsNullOrWhiteSpace(xml))
                return false;

            try
            {
                XDocument.Parse(xml);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsValidJson(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            input = input.Trim();

            // Check if it looks like a JSON object or array
            if (!(input.StartsWith("{") && input.EndsWith("}")) &&
                !(input.StartsWith("[") && input.EndsWith("]")))
                return false;

            try
            {
                JsonDocument.Parse(input);
                return true;
            }
            catch (JsonException)
            {
                return false;
            }
            catch (Exception)
            {
                // Any other exception (e.g., memory issues)
                return false;
            }
        }
    }
}
