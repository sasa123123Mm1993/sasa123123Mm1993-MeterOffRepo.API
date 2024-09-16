using MeterOff.Core.Models.Constant;

namespace MeterOff.Core.Models.Dto.ControlCard
{
    public class TariffDto : BaseDto
    {
        public string Name { get; set; }
        public DateTime ActivationDate { get; set; }
        public int TariffTypeId { get; set; }
        public int? OrganizationStructureId { get; set; }
        public decimal ZeroReading { get; set; }
        public bool CustomerServiceMethod { get; set; }
        public int TariffCode { get; set; }
        public ActivityTypeDto ActivityType { get; set; }
        public OrganizationStructureDto OrganizationStructure { get; set; }


    }
}