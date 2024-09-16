using MeterOff.Core.Models.Constant;

namespace MeterOff.Core.Models.Dto.ControlCard
{
    public class PermissionDto : BaseDto
    {
        public string Name { get; set; }
        public bool IsGranted { get; set; }
        public int? UserId { get; set; }
        public int? RoleId { get; set; }

    }
}