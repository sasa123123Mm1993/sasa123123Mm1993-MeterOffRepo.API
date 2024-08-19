using MeterOff.Core.Models.Base;
using MeterOff.Models.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeterOff.Core.Models.Infrastructure
{
    public partial class DebitPaymentDetail : BaseEntity
    {
      
        public int? DebitPaymentId { get; set; }
        public PaymentStatusEnum Status { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public int? RecieptNumber { get; set; }
      
        public int? OrderId { get; set; }
      
        public int? AdvancePaymentId { get; set; }
      
        public int? AdvancePaymentDetailId { get; set; }
        public bool ISPayFromAdvancePayment { get; set; }
        public bool IsLinkToClearDue { get; set; }
        public DateTime? DueDateBeforeLinkToClearDue { get; set; }

        [ForeignKey("DebitPaymentId")]
        public virtual DebitPayment DebitPayment { get; set; }

        [ForeignKey("AdvancePaymentId")]
        public virtual Deposit AdvancePayment { get; set; }
    }
}
