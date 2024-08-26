using MeterOff.Core.Models.Dto.ControlCard;
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

        IEnumerable<CardFunction> GetAll();
        IEnumerable<Technician> GetAllTecnicions(int? RegionId, string? filter, int? cardFunctionId);
        ControlCardOutput AddContolCard(InsertControlCardInput card);
        bool ValidateMeterSerialNumber(string meterSerialNumber);
        DateTime GetTechinicianExpirationDate();
        DateTime GetTechinicianActivationDate();
        string CancelControlCard(int controlCardId);

    }
}
