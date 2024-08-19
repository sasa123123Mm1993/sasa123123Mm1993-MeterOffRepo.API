using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.Core.Models.Dto.ControlCard
{
    public class GetAllEmployeesSearchOutput
    {
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public string SmallDepartmentCode { get; set; }
        public string SmallDepartment { get; set; }
        public string NationalId { get; set; }
        public bool IsActive { get; set; }
        public bool IsCompanyCardPrivilidge { get; set; }

    }
}
