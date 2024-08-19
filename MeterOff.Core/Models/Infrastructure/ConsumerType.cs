using MeterOff.Core.Models.Base;
using MeterOff.Models.Enum;
using System.ComponentModel.DataAnnotations;
using MeterOff.Core.Models.Enum;

namespace MeterOff.Core.Models.Infrastructure
{
    public partial class ConsumerType : BaseEntity
    {
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(20)]
        public string Code { get; set; }
        public decimal InitialBalance { get; set; }
        public CustomerTypeEnum CustomerTypeEnum { get; set; }
        public CustomerTransformTypeEnum CustomerTransformTypeEnum { get; set; }

    }
}
