
using System.Xml.Serialization;

namespace GPICardCore.Master
{
    [XmlRoot("previousMeterEvent")]
    public class PreviousMeterEvent
    {
        [XmlElement("meterNo")]
        public string MeterNo { get; set; }

        [XmlElement("previousMeterEventCode")]
        public string PreviousMeterEventCode { get; set; }

        [XmlElement("previousMeterEventTime")]
        public string PreviousMeterEventTime { get; set; }

        [XmlElement("previousMeterEventRemovalTime")]
        public string PreviousMeterEventRemovalTime { get; set; }

        [XmlElement("previousMeterEventRemovalCardId")]
        public string PreviousMeterEventRemovalCardId { get; set; }
    }
}
