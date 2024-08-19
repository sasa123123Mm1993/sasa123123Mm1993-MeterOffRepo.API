using MeterOff.Core.Models;
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
        IEnumerable<CMaintenenceMetersOffOutput> GetAll();
        IEnumerable<Section> GetAllSections();
        IEnumerable<MainDepartment> GetAllMainDepartments();
        IEnumerable<MainDepartment> GetAllMainDepartmentsBySectionId(int SectionId);

        IEnumerable<SmallDepartmentDto> GetAllSmallDepartments();
        IEnumerable<SmallDepartment> GetAllSmallDepartmentsByMainDepId(int MainDepId);
        public IEnumerable<CMaintenenceMetersOffOutput> GetDataByRefAddress(int dailyNo, int regionNo, int accountNo, int branchNo);


        IEnumerable<ActivityType> GetAllActivityTypes();

        IEnumerable<PlaceType> GetAllPlaceTypesByActivityTypeId(int ActivityTypeId);
        IEnumerable<PlaceType> GetAllPlaceTypes();
        IEnumerable<MeterType> GetAllMeterTypes();




        CMaintenenceMetersOffOutput GetByIdDtoModel(int id);
        CMaintenenceMetersOff GetByIdTableData(int id);

        CMaintenenceMetersOff Add(CMaintenenceMetersOff model);
        CMaintenenceMetersOff AddFixedMeterToTechinition(CMaintenenceMetersOff model);

        CMaintenenceMetersOff Update(CMaintenenceMetersOff model);
        CMaintenenceMetersOff Delete(CMaintenenceMetersOff model);


    }
}
