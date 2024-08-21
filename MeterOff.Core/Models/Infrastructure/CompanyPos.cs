using MeterOff.Core.Models.Base;
using MeterOff.Models.Enum;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MeterOff.Core.Models.Base;
using MeterOff.Core.Models.Enum;
using MeterOff.Core.Models.Identity;

namespace MeterOff.Core.Models.Infrastructure
{
    public class CompanyPos : BaseEntity
    {
        public CompanyPos()
        {
            Users = new HashSet<ApplicationUser>();
        }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Code { get; set; }
        public int? RegionId { get; set; }//organizationStructureId-Department
        public int? SectionId { get; set; }//organizationStructureId-Section
        public int? departmentId { get; set; }//Department
        public LevelEnum LevelEnum { get; set; }
        public bool IsActive { get; set; }
        public bool IsMobileUnit { get; set; } //1 MobileUnit //0 FixedUnit
        public virtual ICollection<ApplicationUser> Users { get; set; }
       

    }
}
