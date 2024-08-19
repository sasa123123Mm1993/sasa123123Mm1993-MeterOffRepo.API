using MeterOff.Core.Models.Base;
using Microsoft.CodeAnalysis;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeterOff.Core.Models.Infrastructure
{
    public partial class MeterReplaceLog : BaseEntity
    {
        public int AccountId { get; set; }
        public int OldMeterId { get; set; }
        public int NewMeterId { get; set; }
        public int OldReceiptNumber { get; set; }
        public int OrderSequence { get; set; }

        public bool IsFinished { get; set; }

        [ForeignKey("OldMeterId")]
        public virtual MeterData OldMeter { get; set; }
        [ForeignKey("NewMeterId")]
        public virtual MeterData NewMeter { get; set; }
        [ForeignKey("AccountId")]
        public virtual Consumer Account { get; set; }
    }
}
