using MeterOff.Core.Models.Base;
using MeterOff.Models.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeterOff.Core.Models.Infrastructure
{
    public class ConsumerConsumptionFeesCalc : BaseEntity
    {
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public DateTime DueDate { get; set; }
        public PaymentStatusEnum Status { get; set; }
        public bool IsDeffered { get; set; }
        public int TariffId { get; set; }
        public int? OrderId { get; set; }
        public int? MonthlyConsumptionId { get; set; }

        [ForeignKey("MonthlyConsumptionId")]
        public virtual ConsumerConsumption MonthlyConsumption { get; set; }



        [ForeignKey("TariffId")]
        public virtual Tariff Tariff { get; set; }

        [ForeignKey("AccountId")]
        public virtual Consumer Account { get; set; }
    }
}
