using MeterOff.Core.Models.Constant;

namespace MeterOff.Core.Models.Dto.ControlCard
{
    public class OrganizationStructureDto : BaseDto
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public int OrganizationLevelId { get; set; }
        public OrganizationLevelDto OrganizationLevel { get; set; }
        public int? RegionCode { get; set; }
    }
}