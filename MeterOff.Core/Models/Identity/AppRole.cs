using MeterOff.Core.Models.Dto.UserDto;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.Core.Models.Identity
{
    public class AppRole : IdentityRole
    {
        public virtual ICollection<AppRoleDto> UserRoles { get; set; }
        public bool IsDeleted { get; set; }
        public string DisplayName { get; set; }
        public string RoleName { get; set; }


    }
}
