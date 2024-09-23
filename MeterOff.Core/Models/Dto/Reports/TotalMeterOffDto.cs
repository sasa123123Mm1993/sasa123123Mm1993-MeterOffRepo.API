using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.Core.Models.Dto.Reports
{
    public class TotalMeterOffDto
    {
        public int DisabledMeters { get; set; }
        public int EndedMeters { get; set;}
        public int NotRecivedMeters { get; set;}
        public int RecivedMeters { get; set;}
        public int InstalledMeters { get; set;}
        public int NotInstalledMeters { get; set;}
    }
}
