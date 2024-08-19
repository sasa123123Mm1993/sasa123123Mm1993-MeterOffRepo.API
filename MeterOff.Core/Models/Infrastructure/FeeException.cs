using MeterOff.Core.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeterOff.Core.Models.Infrastructure
{
    public partial class FeeException : BaseEntity
    {
        public int FeeId { get; set; }
        public int LevelEnum { get; set; }
        public double ExceptionAmount { get; set; }
        public bool IsNoFees { get; set; }
        public int? SectionNo { get; set; }
        public int? DepartmentNo { get; set; }
        public int? RegionNo { get; set; }
        public int? DailyNo { get; set; }
        public int? AccountNo { get; set; }
        public int? BranchNo { get; set; }
        public int? TariffTypeId { get; set; }
        public int? CustomerTypeId { get; set; }
        public int? BuildingTypeId { get; set; }
        [ForeignKey("FeeId")]
        public virtual FeesType Fee { get; set; }


    }
}
