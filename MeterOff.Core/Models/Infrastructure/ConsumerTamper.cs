using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MeterOff.Core.Models.Base;
using MeterOff.Models.Enum;

namespace MeterOff.Core.Models.Infrastructure
{
    public partial class ConsumerTamper : CollectionCardBaseEntity
    {
        public int TamperId { get; set; }
        [MaxLength(50)]
        public string RemoveBy { get; set; }
        public DateTime? RemoveDate { get; set; }
        public DateTime? RemoveDateFromMeter { get; set; }
        public PaymentStatusEnum PaymentStatus { get; set; }
        public int? ReceiptNumber { get; set; }
        public int? OrderId { get; set; }
        public DateTime? Date { get; set; }
        public decimal Amount { get; set; }
        public bool IsTamperToRemove { get; set; }
        public bool IsTamperToPay { get; set; }
        public bool IsMeterEvent { get; set; } // if true represent that the tamper was on meter and returned from card.

        [ForeignKey("TamperId")]
        public virtual Tamper Tamper { get; set; }




    }
}
