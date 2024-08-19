using MeterOff.Core.Models.Base;
using MeterOff.Models.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeterOff.Core.Models.Infrastructure
{
    public partial class ConsumerConsumptionFee : BaseEntity
    {

        public int? AccountId { get; set; }

        public int? FeeId { get; set; }
        public int? MonthlyConsumptionId { get; set; }
        public double ConsumptionFeesValue { get; set; }
        public PaymentStatusEnum PaymentStatusEnum { get; set; }
        public int? OrderId { get; set; }
        public DateTime? PaymentDate { get; set; }

        [ForeignKey("FeeId")]
        public virtual FeesType Fee { get; set; }


        [ForeignKey("MonthlyConsumptionId")]
        public virtual ConsumerConsumption MonthlyConsumption { get; set; }

        [ForeignKey("AccountId")]
        public virtual Consumer Account { get; set; }
    }
}

