using MeterOff.Core.Models.Dto.CMaintenenceMetersOff;
using MeterOff.Core.Models.Dto.MeterOffReasons;
using MeterOff.Core.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.Core.Interfaces
{
    public interface IMeterOffReasonsRepository
    {
        IEnumerable<CUploadMainteneceMetersOffReason> GetAll();
        Task<CUploadMainteneceMetersOffReason> GetById(int id);
        Task<CUploadMainteneceMetersOffReason> GetByCode(int code);
        Task<CUploadMainteneceMetersOffReason> Add(CUploadMainteneceMetersOffReason cuploadMeterOffReasonsOutput);
        CUploadMainteneceMetersOffReason Update(CUploadMainteneceMetersOffReason cuploadMeterOffReasonsOutput);
        CUploadMainteneceMetersOffReason Delete(CUploadMainteneceMetersOffReason cuploadMeterOffReasonsOutput);
        bool IsvalidCUploadMainteneceMetersOffReason(int? uploadReasonId);
        bool validateInsertCMaintenenceMetersOff(InsertCMaintenenceMetersOffInput data);
        bool ValidateAddFixedMeterToTechinicion(FixedMeterToTechinitionInsert data);
        bool ValidateAddReason(InsertCUploadMainteneceMetersOffReasonInput data);

    }
}
