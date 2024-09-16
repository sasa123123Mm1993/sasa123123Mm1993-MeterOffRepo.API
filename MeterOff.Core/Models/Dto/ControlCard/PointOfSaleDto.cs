using MeterOff.Core.Models.Constant;
using MeterOff.Core.Models.Enum;

namespace MeterOff.Core.Models.Dto.ControlCard
{
    public class PointOfSaleDto : BaseDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int RegionId { get; set; }
        public int? departmentId { get; set; }//Department

        public bool IsActive { get; set; }
        public bool IsMobileUnit { get; set; }
        public int SectionId { get; set; }//organizationStructureId-Section
        public LevelEnum LevelEnum { get; set; }

        public OrganizationStructureDto OrganizationStructure { get; set; }
        public OrganizationStructureDto Department { get; set; }
    }
}