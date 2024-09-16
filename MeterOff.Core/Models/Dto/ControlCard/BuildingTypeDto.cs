using MeterOff.Core.Models.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.Core.Models.Dto.ControlCard
{
    public class BuildingTypeDto : BaseDto
    {
        public string Name { get; set; }
        public int? TariffTypeId { get; set; }
        public int Code { get; set; }
        public string Notes { get; set; }
        public ActivityTypeDto ActivityType { get; set; }
    }

    public class ActivityTypeDto : BaseDto
    {
        public string Name { get; set; }
        public decimal InitialBalance { get; set; }
        public decimal MinimumCharge { get; set; }
        public decimal MaximumCharge { get; set; }
        public int TariffTypeCode { get; set; }
        public bool ISsmall { get; set; }
        public bool ISBig { get; set; }
        public int StutsBigSmall { get; set; }
    }
}
