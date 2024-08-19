using MeterOff.Core.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeterOff.Core.Models.Infrastructure
{
    public partial class Deposit : BaseEntity
    {
        public Deposit()
        {
            AdvancePaymentDetails = new HashSet<DepositDetail>();
            DebitPaymentDetails = new HashSet<DebitPaymentDetail>();

        }
        public decimal TotalAmount { get; set; }
        public decimal RemainingAmount { get; set; }
        public int? AdvancePaymentTypeId { get; set; }
        public int AccountId { get; set; }
      
        [ForeignKey("AccountId")]
        public virtual Consumer Account { get; set; }
        public virtual ICollection<DepositDetail> AdvancePaymentDetails { get; set; }
        public virtual ICollection<DebitPaymentDetail> DebitPaymentDetails { get; set; }

    }
}
