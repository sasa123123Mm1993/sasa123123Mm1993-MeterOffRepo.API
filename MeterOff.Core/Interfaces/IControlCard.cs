using MeterOff.Core.Models.Base;
using MeterOff.Core.Models.Dto.CardFunctionDto;
using MeterOff.Core.Models.Dto.ControlCard;
using MeterOff.Core.Models.Dto.Reports;
using MeterOff.Core.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.Core.Interfaces
{
    public interface IControlCard
    {

        Response<List<CardFunctionDto>> GetAll();
        Response<List<Technician>> GetAllTecnicions(int? RegionId, string? filter, int? cardFunctionId);
        Response<ControlCardOutput> AddContolCard(InsertControlCardInput card);
        bool ValidateMeterSerialNumber(string meterSerialNumber);
        Response<DateTime> GetTechinicianExpirationDate();
        Response<DateTime> GetTechinicianActivationDate();
        Response<bool> CancelControlCard(string controlCardId);
        Response<ControlLaunchOutput> ReadControlLaunch();
        Response<List<Tamper>> GetAllTempers();
    }
}
