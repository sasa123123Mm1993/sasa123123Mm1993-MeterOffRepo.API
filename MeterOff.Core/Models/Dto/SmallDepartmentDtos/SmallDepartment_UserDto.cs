using MeterOff.Core.Models.Dto.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.Core.Models.Dto.SmallDepartmentDtos
{
    public class SmallDepartment_UserDto
    {
        public int SmallDepartmentId { get; set; }
        public virtual SmallDepartmentDto SmallDepartment { get; set; }
        public string AppUserId { get; set; }
        public virtual AppUserDto AppUser { get; set; }
    }
}
