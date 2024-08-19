
using MeterOff.Core.Models.Base;

namespace MeterOff.Core.Models.Infrastructure
{
    public partial class OpenConsumerCardLog : BaseEntity
    {
        public int AccountId { get; set; }
        public int? MeterId { get; set; }
        public int? EmployeeId { get; set; }
    }
}
