
using MeterOff.Core.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeterOff.Core.Models.Infrastructure
{
    public class ChargeLog : BaseEntity
    {
        public string OrderId { get; set; }
        public string TransactionDate { get; set; }
        public string TotalAmount { get; set; }
        public string NetAmount { get; set; }
        public int AccountId { get; set; }
        public string DebitAmount { get; set; }
        public string FeesAmount { get; set; }
        public string AccountTamperFees { get; set; }
        public string OrderSequence { get; set; }
        public string OrderCreationTime { get; set; }
        public string OrderModificationTime { get; set; }
        public string OrderCreatorById { get; set; }
        public string OrderModifiedById { get; set; }

        [ForeignKey("AccountId")]
        public virtual Consumer Account { get; set; }
    }
}
