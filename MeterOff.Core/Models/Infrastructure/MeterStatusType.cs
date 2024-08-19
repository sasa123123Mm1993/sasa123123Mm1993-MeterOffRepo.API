using MeterOff.Core.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace MeterOff.Core.Models.Infrastructure
{
    public partial class MeterStatusType : BaseEntity
    {
        public MeterStatusType()
        {
            //MeterStatusHistory = new HashSet<MeterStatusLog>();
        }
        [MaxLength(200)]
        public string Description { get; set; }
        public virtual ICollection<MeterStatusLog> MeterStatusHistory { get; set; }
    }
}
