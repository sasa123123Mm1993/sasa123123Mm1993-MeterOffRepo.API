using MeterOff.Core.Models.Constant;

namespace MeterOff.Core.Models.Dto.ControlCard
{
    public class CustomerDto : BaseDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string NationalId { get; set; }
        public string PassPort { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

    }
}