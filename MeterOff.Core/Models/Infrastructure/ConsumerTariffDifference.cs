using MeterOff.Core.Models.Base;
using MeterOff.Models.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeterOff.Core.Models.Infrastructure
{
    public class ConsumerTariffDifference : BaseEntity
    {
        public int AccountId { get; set; }
        public int CurrentAccountTariffId { get; set; }
        public decimal Consumption { get; set; } //from Card [previous Consumption History]
        public double Amount { get; set; } //from Card [previous Consumption History]
        public double AmountWithCurrentAccountTariff { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int? OrderId { get; set; }
        public double TariffDifferenceAmount { get; set; }
        public PaymentStatusEnum? PaymentStatus { get; set; }
        public DateTime? PaymentDate { get; set; }

        [ForeignKey("AccountId")]
        public virtual Consumer Account { get; set; }
      

    }
}
