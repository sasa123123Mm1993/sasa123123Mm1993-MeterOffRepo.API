using MeterOff.Core.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeterOff.Core.Models.Infrastructure
{
    public class TechnicianDepartment : BaseEntity
    {
        
        public int DepartmentId { get; set; }
        public int EmployeeId { get; set; } //Id from OrganizationStructure

        [ForeignKey("EmployeeId")]
        public virtual Technician Employee { get; set; }
        
        //[ForeignKey("DepartmentId")]
        //public virtual CompanyHierarchical OrganizationStructure { get; set; }
    }
}
