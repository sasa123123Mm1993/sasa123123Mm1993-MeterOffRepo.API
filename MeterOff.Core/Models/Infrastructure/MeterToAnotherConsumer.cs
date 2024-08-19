using MeterOff.Core.Models.Base;
using Microsoft.CodeAnalysis;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeterOff.Core.Models.Infrastructure
{
    public partial class MeterToAnotherConsumer : BaseEntity
    {
        public int NewAccountId { get; set; }
        public int OldAccountId { get; set; }
        public int? MeterId { get; set; }
        public int? ConsumerId { get; set; }
        [ForeignKey("MeterId")]
        public virtual MeterData Meter { get; set; }

    }
}
