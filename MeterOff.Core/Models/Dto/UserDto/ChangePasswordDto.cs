using MeterOff.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.Core.Models.Dto.UserDto
{
   public class ChangePasswordDto
    {
        public string? UserId { get; set; }
        public string? currentPassword { get; set; }
        public string? newPassword { get; set; }
    }

    public class ChangePasswordDtoOutput : PayLoad<ChangePasswordDto>
    {
        //public string? UserId { get; set; }
        //public string? currentPassword { get; set; }
        //public string? newPassword { get; set; }
    }
}
