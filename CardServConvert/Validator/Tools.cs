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


    }
}
