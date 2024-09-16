using MeterOff.Core.Models.Constant;
using MeterOff.Core.Models.Enum;

namespace MeterOff.Core.Models.Dto.ControlCard
{
    public class EmployeeDto : BaseDto
    {
        public string Name { get; set; }
        public string NationalId { get; set; }
        public DateTime? HireDate { get; set; }
        public DateTime? BirthDate { get; set; }
        public int DepartmentId { get; set; }
        public int? SectionId { get; set; }
        public LevelEnum LevelEnum { get; set; }
        public int? UserId { get; set; }
        public int? ParentId { get; set; }
        public int? SupervisiorId { get; set; }
        public int EmployeeGroupId { get; set; }
        public UserDto User { get; set; }
        public DepartmentDto Department { get; set; }
        public int? RegionId { get; set; }
        public int? SmallDepartmentId { get; set; }
        public bool IsActive { get; set; }
        public bool IsCompanyCardPrivilidge { get; set; }
        public bool IsDepartmentUpdate { get; set; }
        public bool IsEmployeeNew { get; set; }
        public List<int> EmployeeDepartmentIds { get; set; }
    }
}