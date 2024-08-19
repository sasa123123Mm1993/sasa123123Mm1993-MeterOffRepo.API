using MeterOff.Core.Models.Base;
using MeterOff.Models.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeterOff.Core.Models.Infrastructure
{
    public partial class ConsumerFee : BaseEntity
    {

        public int AccountId { get; set; }
        public int FeeId { get; set; }
        public PaymentStatusEnum PaymentStatus { get; set; }
        public double Amount { get; set; }
        public int? OrderId { get; set; }
        public int? ReceiptNumber { get; set; }
        public DateTime? PaymentDate { get; set; }
        public DateTime DueDate { get; set; }
        [ForeignKey("FeeId")]
        public virtual FeesType Fee { get; set; }
        [ForeignKey("AccountId")]
        public virtual Consumer Account { get; set; }
       
    }
}
