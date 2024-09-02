using MeterOff.Core.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.Core.Models.Infrastructure
{
    public class MetersDataInput
    {
        public MetersDataInput()
        {
            Status = (int)MeterMaintenanceEnum.All;
            PageNumber = 1;
            PageSize = 50;
        }
        public string Filter { get; set; }
        public string TypeFilter { get; set; }
        public string Filter2 { get; set; }
        public string VendorCode { get; set; }

        public string TypeFilter2 { get; set; }
        public int SearchType2 { get; set; }

        public string SectorNo { get; set; }
        public string DepartmentNo { get; set; }
        public string SmallDepartmentNo { get; set; }
        public string RegionNo { get; set; }
        public string DailyNo { get; set; }
        public string AccountNo { get; set; }
        public string BranchNo { get; set; }

        public int Status { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string IsDeleted { get; set; }
        public string StatusOfMeter { get; set; }
    }
}
