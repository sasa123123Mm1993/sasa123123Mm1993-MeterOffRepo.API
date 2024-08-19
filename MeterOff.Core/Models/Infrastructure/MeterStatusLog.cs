using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MeterOff.Core.Models.Base;

namespace MeterOff.Core.Models.Infrastructure
{
    public partial class MeterStatusLog : BaseEntity
    {
        public int MeterId { get; set; }
        public int MeterStatusId { get; set; }
        [MaxLength(200)]
        public string Note { get; set; }
        public DateTime Date { get; set; }
        public DateTime PassingDate { get; set; }
        public bool IsCurrent { get; set; }


        [ForeignKey("MeterStatusId")]
        public virtual MeterStatusType MeterStatus { get; set; }
    }
}
