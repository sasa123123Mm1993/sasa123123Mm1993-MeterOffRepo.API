using MeterOff.Core.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MeterOff.Core.Models.Infrastructure
{
    public partial class CutoffHistory : BaseEntity
    {
        [MaxLength(100)]
        public string Time { get; set; }
        [MaxLength(100)]
        public string Reason { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        public int InstantaneousReadingId { get; set; }

        [ForeignKey("InstantaneousReadingId")]
        public virtual CurrentReading InstantaneousReading { get; set; }

    }
}
