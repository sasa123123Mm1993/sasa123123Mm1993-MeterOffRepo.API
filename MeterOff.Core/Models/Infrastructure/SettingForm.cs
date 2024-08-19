using MeterOff.Core.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace MeterOff.Core.Models.Infrastructure
{
    public partial class SettingForm : BaseEntity
    {
        public SettingForm()
        {
            ConfigurationTemplateDetails = new HashSet<SettingFormsData>();
            MeterTypeConfigurationTemplates = new HashSet<MeterSettingForm>();
        }
        [MaxLength(100)]
        public string Name { get; set; }
        public virtual ICollection<SettingFormsData> ConfigurationTemplateDetails { get; set; }
        public virtual ICollection<MeterSettingForm> MeterTypeConfigurationTemplates { get; set; }
    }
}
