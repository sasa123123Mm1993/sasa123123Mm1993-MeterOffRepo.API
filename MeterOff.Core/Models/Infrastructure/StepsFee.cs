using MeterOff.Core.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeterOff.Core.Models.Infrastructure
{
    public partial class StepsFee : BaseEntity
    {
        public int From { get; set; }
        public int To { get; set; }
        public decimal Amount { get; set; }
        public int? FeeId { get; set; }

        [ForeignKey("FeeId")]
        public virtual FeesType Fee { get; set; }


    }
}
