using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.Core.Interfaces
{
    public interface ISessionManager
    {
        int? UserId { get; }
        int? PosId { get; }
        int? RegionId { get; }
        int? DepartmentId { get; }
        string UserType { get; }
        int? CurrentPosCode { get; }
    }
}
