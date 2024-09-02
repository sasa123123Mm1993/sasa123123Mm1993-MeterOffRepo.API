using MeterOff.Core.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.Core.Models.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public string Code { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string NationalId { get; set; }
        public virtual ICollection<Section> Sections { get; set; } //قطاعات
        public virtual ICollection<SmallDepartment> SmallDepartments { get; set; }
        //public virtual ICollection<SmallDepartment_User> SmallDepartment_Users { get; set; }
        //public virtual ICollection<AppUserRole> UserRoles { get; set; } 
    }

    public class userData : IdentityUser
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Code { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string NationalId { get; set; }
        public virtual ICollection<Section> Sections { get; set; } //قطاعات
        public virtual ICollection<SmallDepartment> SmallDepartments { get; set; }
       
    }
}
