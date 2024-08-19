using MeterOff.Core.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace MeterOff.Core.Models.Infrastructure
{
    public partial class EmployeeGroup : BaseEntity
    {
        [MaxLength(150)]
        public string Name { get; set; }
    }
}
