using GPICardCore.Master;
using System.Xml.Linq;

namespace GPICardCore.Reader
{


    public class CardXmlReader
    {
        private readonly XDocument _document;
        private readonly Dictionary<string, string> _flatElements;

        public CardXmlReader(string xmlData)
        {
           
            _document = XDocument.Parse(xmlData);
            _flatElements = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            foreach (var element in _document.Descendants())
            {
                if (!element.HasElements && !string.IsNullOrWhiteSpace(element.Name.LocalName))
                {
                    _flatElements[element.Name.LocalName] = element.Value;
                }
            }
        }

        // Returns single value if it's a simple tag (like manufacturerId)
        public string GetValue(string tagName)
        {
            return _flatElements.TryGetValue(tagName, out var value) ? value.Trim() : null;
        }

        // Returns value of child tag under a parent tag (e.g., controlCardActivationDate under controlCardActivationPeriod)
        public string GetChildValue(string parentTag, string childTag)
        {
            var parent = _document.Descendants(parentTag).FirstOrDefault();
            return parent?.Element(childTag)?.Value;
        }

        // Returns list of child tag values under a repeating parent structure (e.g., multiple <holidayDate> under <holidays>)
        public List<string> GetListValues(string parentTag, string childTag)
        {
            var parent = _document.Descendants(parentTag).FirstOrDefault();
            return parent?.Elements(childTag).Select(e => e.Value).Where(v => !string.IsNullOrWhiteSpace(v)).ToList()
                   ?? new List<string>();
        }


        public ControlCardType GetControlCardType()
        {
            var cardType = GetValue("cardType");
            var controlOperationType = GetValue("controlOperationType");           
            var setDateAndTimeMode = GetValue("setDateAndTimeMode");
            var resetMeterMode = GetValue("resetMeterMode");
            var customerOperationType = GetValue("customerOperationType");
            var editMeterDataOperation = GetValue("editMeterDataOperation");



            if (cardType == "1")
            {
                if (controlOperationType == "1")
                {
                    return ControlCardType.CopyMeter;
                }

                if (controlOperationType == "3")
                {
                    return ControlCardType.ClearTamper;
                }

                if (controlOperationType == "4" && editMeterDataOperation =="1")
                {
                    return ControlCardType.TarrifUpdate;
                }

                if (controlOperationType == "4" && editMeterDataOperation == "0")
                {
                    return ControlCardType.AlarmCutoffLimits;
                }

                if (controlOperationType == "5")
                {
                    return ControlCardType.RelayToggle;
                }

                if (controlOperationType == "6"  )
                {
                    return ControlCardType.RelayTest;
                }

                if (controlOperationType == "50")
                {
                    return ControlCardType.ChangeCompany;
                }

                if (controlOperationType == "51")
                {
                    return ControlCardType.ChangeMeterNumber;
                }

                if (controlOperationType == "52")
                {
                    return ControlCardType.LunchCurrent;
                }

                if (controlOperationType == "53")
                {
                    return ControlCardType.Lab;
                }

                if (controlOperationType == "0"  && setDateAndTimeMode == "0")
                {
                    return ControlCardType.SetDateTimeAuto;
                }

                if (controlOperationType == "0" && setDateAndTimeMode == "1")
                {
                    return ControlCardType.SetDateTimeManual;
                }


            }

            if (cardType == "0" &&  resetMeterMode == "0" &&  customerOperationType == "2")
            {
                return ControlCardType.ResetMeter;
                                        
            }
         

            return  ControlCardType.UnknownNotSupported;
        }
     
    }
}
