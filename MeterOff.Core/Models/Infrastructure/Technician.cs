using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MeterOff.Core.Models;
using MeterOff.Core.Models.Base;
using MeterOff.Core.Models.Enum;

namespace MeterOff.Core.Models.Infrastructure
{
    public partial class Technician : BaseEntity
    {

        [MaxLength(100)]
        public string Name { get; set; }
        public DateTime? HireDate { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? RegionId { get; set; }
        public bool IsDepartmentUpdate { get; set; }
        public LevelEnum LevelEnum { get; set; }
        [MaxLength(20)]
        public string NationalId { get; set; }
        public bool IsActive { get; set; }
        public bool IsCompanyCardPrivilidge { get; set; }

        public bool IsEmployeeNew { get; set; }

        public int TechnicianTypeId { get; set; }
        public virtual TechnicianType technicianTypes { get; set; }

        public virtual ICollection<Section> Sections { get; set; }
        //public virtual ICollection<CompanyHierarchical> CompanyHierarchicals { get; set; } //شركة

        public virtual ICollection<SmallDepartment> SmallDepartments { get; set; }//ادارة فرعية
    }
}
