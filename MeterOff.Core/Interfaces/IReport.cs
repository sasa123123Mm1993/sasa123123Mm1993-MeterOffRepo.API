using MeterOff.Core.Models.Dto.Reports;
using MeterOff.Core.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MeterOff.Core.Interfaces
{
    public interface IReport
    {
        public Task<IEnumerable<CMaintenenceMetersOffDto>> GetAllData(MetersDataInput metersDataInput);

    }
}
