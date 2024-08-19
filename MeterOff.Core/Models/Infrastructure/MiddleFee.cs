using MeterOff.Core.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeterOff.Core.Models.Infrastructure
{
    public partial class MiddleFee : BaseEntity
    {
        public int ContractFeeTypeId { get; set; }
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public int ReceiptNumber { get; set; }

        [ForeignKey("ContractFeeTypeId")]
        public virtual MiddleFeesType ContractFeesType { get; set; }
        [ForeignKey("AccountId")]
        public virtual Consumer Account { get; set; }

    }
}
