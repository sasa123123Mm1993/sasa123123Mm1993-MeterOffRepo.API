using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.Core.Models.Dto.ControlCard
{
    public class AccountLanchTampers
    {
        public List<AccountLanchTamper> allPutOnMeterAccountLanchTamer { get; set; }
        public List<AccountLanchTamper> BeforePutOnMeterAccountLanchTamer { get; set; }
        public List<AccountLanchTamper> AfterPutOnMeterallAccountLanchTamer { get; set; }
    }

    public class AccountLanchTamper
    {
        public string TamperCode { get; set; }
        public string TamperName { get; set; }
        public DateTime? ProcessingTimestamp { get; set; }
        public DateTime? MeterInstallationDate { get; set; }
        public DateTime? CreationTime { get; set; }
    }

    public class AllControlCardOutput
    {
        public AllControlCardOutput()
        {
            Meters = new List<MeterInfo>();
        }
        public List<MeterInfo> Meters { get; set; }
        public AllControlCardDto ControlCard { get; set; }
        public List<InsertCardTamperInput> RemovedTampers { get; set; }


    }



}
