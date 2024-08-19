using MeterOff.Core.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeterOff.Core.Models.Infrastructure
{
    public partial class MeterSettingForm : BaseEntity
    {
        public int MeterTypeId { get; set; }
        public int ConfigurationTemplateId { get; set; }
        [ForeignKey("MeterTypeId")]
        public virtual MeterType MeterType { get; set; }
        [ForeignKey("ConfigurationTemplateId")]
        public virtual SettingForm ConfigurationTemplate { get; set; }
    }
}
