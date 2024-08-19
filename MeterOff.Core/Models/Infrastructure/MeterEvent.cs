using MeterOff.Core.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MeterOff.Core.Models.Infrastructure
{
    public partial class MeterEvent : BaseEntity
    {
        [MaxLength(200)]
        public string Description { get; set; }
        [MaxLength(100)]
        public string Code { get; set; }
        [MaxLength(100)]
        public string EventTime { get; set; }
        [MaxLength(100)]
        public string RemovedBy { get; set; }
        [MaxLength(100)]
        public string RemovalTime { get; set; }
        public int InstantaneousReadingId { get; set; }
        [ForeignKey("InstantaneousReadingId")]
        public virtual CurrentReading InstantaneousReading { get; set; }
    }
}
