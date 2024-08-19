using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MeterOff.Core.Models.Base;

namespace MeterOff.Core.Models.Infrastructure
{
    public partial class ReplaceCardLog : BaseEntity
    {
        public int AccountId { get; set; }
        [MaxLength(30)]
        public string NewCardNumber { get; set; }
        [MaxLength(30)]
        public string OldCardNumber { get; set; }
        public DateTime ReplacementDate { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
      
        public Guid? CardUid { get; set; }
        [MaxLength(5)]
        public string GenerationCardType { get; set; }

        public int? ReceiptNumber { get; set; }
        public int? OrderId { get; set; }
        public decimal? CardPrice { get; set; }
        [ForeignKey("AccountId")]
        public virtual Consumer Account { get; set; }
        public DateTime? SetDateTime { get; set; }
        public string TampersToRemove { get; set; }
        public string CardType { get; set; }
        public bool IsReplaceWithRecharge { get; set; }
    }
}
