using MeterOff.Core.Models.Base;
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
        Response<List<CUploadMainteneceMetersOffReason>> GetAll();
        Response<CUploadMainteneceMetersOffReason> GetById(int id);
        Response<CUploadMainteneceMetersOffReason> GetByCode(int code);
        Response<CUploadMainteneceMetersOffReason> Add(CUploadMainteneceMetersOffReason cuploadMeterOffReasonsOutput);
        Response<CUploadMainteneceMetersOffReason> Update(int id,CUploadMainteneceMetersOffReason cuploadMeterOffReasonsOutput);
        Response<bool> Delete(int id);
       
        
        Response<string> ValidateAddReason(InsertCUploadMainteneceMetersOffReasonInput data);
        Response<string> ValidateUpdateReason(InsertCUploadMainteneceMetersOffReasonInput model);
       
        bool IsvalidCUploadMainteneceMetersOffReason(int? uploadReasonId);

        //IEnumerable<CUploadMainteneceMetersOffReason> GetAll();
        //Task<CUploadMainteneceMetersOffReason> GetById(int id);
        //Task<CUploadMainteneceMetersOffReason> GetByCode(int code);
        //Response<CUploadMainteneceMetersOffReason> Add(CUploadMainteneceMetersOffReason cuploadMeterOffReasonsOutput);
        //CUploadMainteneceMetersOffReason Update(CUploadMainteneceMetersOffReason cuploadMeterOffReasonsOutput);
        //CUploadMainteneceMetersOffReason Delete(CUploadMainteneceMetersOffReason cuploadMeterOffReasonsOutput);

        //bool validateInsertCMaintenenceMetersOff(InsertCMaintenenceMetersOffInput data);
        //bool validateUpdateCMaintenenceMetersOff(InsertCMaintenenceMetersOffInput data);
        //bool ValidateAddFixedMeterToTechinicion(FixedMeterToTechinitionInsert data);
        //bool ValidateAddReason(InsertCUploadMainteneceMetersOffReasonInput data);


    }
}
