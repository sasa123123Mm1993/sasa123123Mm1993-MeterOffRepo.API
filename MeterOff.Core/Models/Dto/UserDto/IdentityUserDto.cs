using MeterOff.Core.Interfaces;
using MeterOff.Core.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.Core.Models.Dto.UserDto
{
    public class IdentityUserDto : ApplicationUser
    {
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
