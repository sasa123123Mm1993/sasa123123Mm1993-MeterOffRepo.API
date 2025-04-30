using System.Xml.Serialization;

namespace GPICardCore.Master
{
    [XmlRoot("processedMeter")]
    public class ProcessedMeter
    {
        [XmlElement("processedMeterId")]
        public string ProcessedMeterId { get; set; }

        [XmlElement("processingTimestamp")]
        public string ProcessingTimestamp { get; set; }

        [XmlElement("currentMeterStatus")]
        public string CurrentMeterStatus { get; set; }

        [XmlElement("oldMeterStatus")]
        public string OldMeterStatus { get; set; }

        [XmlElement("meterInstallationDate")]
        public string MeterInstallationDate { get; set; }

        [XmlElement("meterInstallerID")]
        public string MeterInstallerID { get; set; }

        [XmlElement("customerId")]
        public string CustomerId { get; set; }
    }

 
}
