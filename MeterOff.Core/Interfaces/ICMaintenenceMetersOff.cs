using MeterOff.Core.Models;
using MeterOff.Core.Models.Base;
using MeterOff.Core.Models.Dto.CMaintenenceMetersOff;
using MeterOff.Core.Models.Dto.SmallDepartmentDtos;
using MeterOff.Core.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.Core.Interfaces
{
    public interface ICMaintenenceMetersOff
    {

        Response<List<CMaintenenceMetersOffOutput>> GetAll();
        Response<List<Section>> GetAllSections();
        Response<List<MainDepartment>> GetAllMainDepartments();
        Response<List<MainDepartment>> GetAllMainDepartmentsBySectionId(int SectionId);
        Response<List<SmallDepartmentDto>> GetAllSmallDepartments();
        Response<List<SmallDepartment>> GetAllSmallDepartmentsByMainDepId(int MainDepId);
        Response<List<CMaintenenceMetersOffOutput>> GetDataByRefAddress(int dailyNo, int regionNo, int accountNo, int branchNo);
        Response<List<ActivityType>> GetAllActivityTypes();
        Response<List<PlaceType>> GetAllPlaceTypesByActivityTypeId(int ActivityTypeId);
        Response<List<PlaceType>> GetAllPlaceTypes();
        Response<List<MeterType>> GetAllMeterTypes();
        Response<CMaintenenceMetersOffOutput> GetByIdDtoModel(int id);
        Response<CMaintenenceMetersOff> GetByIdTableData(int id);
        Response<CMaintenenceMetersOff> Add(InsertCMaintenenceMetersOffInput model);
        
        Response<CMaintenenceMetersOff> Update(int id, InsertCMaintenenceMetersOffInput model);
        Response<CMaintenenceMetersOff> AddFixedMeterToTechinition(int id, FixedMeterToTechinitionInsert model);

        Response<bool> Delete(int id);
        bool validateUpdateCMaintenenceMetersOff(InsertCMaintenenceMetersOffInput model);
        bool validateInsertCMaintenenceMetersOff(InsertCMaintenenceMetersOffInput data);
        bool ValidateAddFixedMeterToTechinicion(FixedMeterToTechinitionInsert data);
    }
}
