using MeterOff.Core.Models.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.Core.Models.Dto.ControlCard
{
    public class UserDto : BaseDto
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public List<PermissionDto> Permissions { get; set; }
        public List<UserRoleDto> Roles { get; set; }
        public int? RegionId { get; set; }
        public string SecurityKey { get; set; }
        public bool IsLoginByCard { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdminSection { get; set; }
        public int? Code { get; set; }
        public int? PointOfSaleId { get; set; }
        public bool IsAllowHHRecharge { get; set; }
        public PointOfSaleDto PointOfSale { get; set; }
        public OrganizationStructureDto Departments { get; set; }
        public List<UpdateUserPosInput> PointOfSales { get; set; }
    }
}
