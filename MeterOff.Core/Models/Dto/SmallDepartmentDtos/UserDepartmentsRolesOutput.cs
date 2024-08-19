using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.Core.Models.Dto.SmallDepartmentDtos
{
    public class UserDepartmentsRolesOutput
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Code { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string NationalId { get; set; }
        public string Id { get; set; }
        public string RoleId { get; set; }
        public List<int> UserSmallDepartmentIDs { get; set; }
    }
}
