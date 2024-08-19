using MeterOff.Core.Models.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.Core.Models.Dto.CMaintenenceMetersOff
{
    public class FixedMeterToTechinitionInsert : BaseDto
    {
        public DateTime? InstallationDate { get; set; }
        public DateTime? DeliveryDateToTechnician { get; set; }
        public DateTime? MaintenanceDate { get; set; }
    }
}
