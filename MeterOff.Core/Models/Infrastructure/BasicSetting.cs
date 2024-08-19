using MeterOff.Core.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace MeterOff.Core.Models.Infrastructure
{
    public class BasicSetting : BaseEntity
    {
        public long CardNumber { get; set; }
        public long AccountCode { get; set; }
        [MaxLength(50)]
        public string MFPCode { get; set; }
    }
}
