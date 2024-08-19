using MeterOff.Models.Enum;
using MeterOff.Core.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeterOff.Core.Models.Infrastructure
{
    public partial class Settlement : BaseEntity
    {
        public Settlement()
        {
            DebitPayments = new HashSet<DebitPayment>();
        }
      
        public int AccountId { get; set; }
        public int DebitTypeId { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal RemainingAmount { get; set; }
        public DateTime DebitDate { get; set; }
        public PaymentStatusEnum Status { get; set; }
        public bool IsHasDiminishingInterest { get; set; } //فائدة تناقصية
        public decimal DiminishingInterestValue { get; set; }
        public decimal DiminishingInterestNet { get; set; }

        [ForeignKey("DebitTypeId")]
        public virtual SettlementType DebitType { get; set; }

        [ForeignKey("AccountId")]
        public virtual Consumer Account { get; set; }

        public virtual ICollection<DebitPayment> DebitPayments { get; set; }
    }
}
