using MeterOff.Core.Models.Dto.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.Core.Models.Dto.SmallDepartmentDtos
{
    public class GetSmallDepartmentsByUserIdOutput
    {
        public AppUserDto AppUser { get; set; }
        public List<SmallDepartmentDto> SmallDepartments { get; set; }
        public string RoleId { get; set; }
    }
}
