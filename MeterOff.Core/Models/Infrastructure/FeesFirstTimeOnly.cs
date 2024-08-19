using MeterOff.Models.Enum;
using MeterOff.Core.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeterOff.Core.Models.Infrastructure
{
    public partial class FeesFirstTimeOnly : BaseEntity
    {
        public int AccountId { get; set; }
        public int FeeId { get; set; }
        public PaymentStatusEnum Status { get; set; }
        public DateTime? PaidDate { get; set; } // تاريخ الدفع
        public int? OrderId { get; set; }
        [ForeignKey("AccountId")]
        public virtual Consumer Account { get; set; }
        [ForeignKey("FeeId")]
        public virtual FeesType Fee { get; set; }
    }
}
