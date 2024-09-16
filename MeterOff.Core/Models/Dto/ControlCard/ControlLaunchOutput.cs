using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.Core.Models.Dto.ControlCard
{
    public class ControlLaunchOutput
    {
        //public ControlLaunchOutput()
        //{
        //    Meters = new List<MeterInfo>();
        //}
        public List<MeterInfo> Meters { get; set; }
        public AllControlCardDto ControlCard { get; set; }
    }

    public class MeterInfo
    {
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string MeterSerial { get; set; }
        public string MeterTimeStamp { get; set; }
        public string ProcessingTimestamp { get; set; }
        public string MeterInstallationDate { get; set; }
        public string meterInstallerID { get; set; }
        public string OldMeterStatus { get; set; }
        public string CurrentMeterStatus { get; set; }
        public string Notes { get; set; }
        public AccountDto Account { get; set; }
        public AccountLanchTampers Tampers { get; set; }



    }
}
