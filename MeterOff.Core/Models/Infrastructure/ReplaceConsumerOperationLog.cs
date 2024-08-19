using MeterOff.Core.Models.Base;
using MeterOff.Core.Models.Enum;
using Microsoft.CodeAnalysis;

namespace MeterOff.Core.Models.Infrastructure
{
    public partial class ReplaceConsumerOperationLog : BaseEntity
    {
        public int? AccountId { get; set; }
        public int? MeterId { get; set; }
        public decimal Amount { get; set; }
        public int ReceiptNumber { get; set; }
        public AccountOperationLogEnum AccountOperationLogEnum { get; set; }
        public DateTime OperationDate { get; set; }
        public virtual Consumer Account { get; set; }
        public virtual MeterData Meter { get; set; }
    }
}
