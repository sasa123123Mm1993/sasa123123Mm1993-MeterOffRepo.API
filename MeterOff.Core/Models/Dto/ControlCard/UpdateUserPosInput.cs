using MeterOff.Core.Models.Constant;

namespace MeterOff.Core.Models.Dto.ControlCard
{
    public class UpdateUserPosInput : BaseDto
    {
        public int PointOfSaleId { get; set; }
        public int UserId { get; set; }
    }
}