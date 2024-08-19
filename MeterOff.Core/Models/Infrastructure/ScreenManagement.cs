using MeterOff.Core.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace MeterOff.Core.Models.Infrastructure
{
    public class ScreenManagement : BaseEntity
    {
        [MaxLength(100)]
        public string Name { get; set; }
        public bool IsAllowToAllDepartment { get; set; }
    }
}
