using MeterOff.Core.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MeterOff.Models.Enum;

namespace MeterOff.Core.Models.Infrastructure
{
    public partial class FeesType : BaseEntity
    {
        public FeesType()
        {
            AccountFees = new HashSet<ConsumerFee>();
            FeesSteps = new HashSet<StepsFee>();
            FeeExceptions = new HashSet<FeeException>();
            TariffFees = new HashSet<TariffFee>();
        }
        [MaxLength(100)]
        public string Name { get; set; }
        public PaymentTypeEnum PaymentType { get; set; }
        public double Amount { get; set; }
        public int? TariffTypeId { get; set; }
        public int? RegionId { get; set; }
        public bool IsMeterDeduction { get; set; }
        public int? Month { get; set; }
        public int? ForEveryKw { get; set; }
        public double? LimitFor { get; set; }
        public double? InSpecificKw { get; set; }
        public double? FromKw { get; set; }
        public double? ToKw { get; set; }
        public string Notes { get; set; }
        public int? Code { get; set; }

        [ForeignKey("TariffTypeId")]
        public virtual ActivityType ActivityType { get; set; }
   
        public virtual ICollection<ConsumerFee> AccountFees { get; set; }
        public virtual ICollection<StepsFee> FeesSteps { get; set; }
        public virtual ICollection<FeeException> FeeExceptions { get; set; }
        public virtual ICollection<TariffFee> TariffFees { get; set; }

    }
}
