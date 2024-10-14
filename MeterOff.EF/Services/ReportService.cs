using Dapper;
using MeterOff.Core.Interfaces;
using MeterOff.Core.Models.Base;
using MeterOff.Core.Models.Dto.CMaintenenceMetersOff;
using MeterOff.Core.Models.Dto.Reports;
using MeterOff.Core.Models.Exception;
using MeterOff.Core.Models.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MeterOff.EF.Services
{
    public class ReportService : IReport
    {
        private readonly DBContext _context;
        private readonly DapperContext _dapperContext;
        public ReportService(DBContext context, DapperContext dapperContext)
        {
            _context = context;
            _dapperContext = dapperContext; 
        }

        public async Task<IEnumerable<CMaintenenceMetersOffDto>> GetAllData(MetersDataInput metersDataInput)
        {
            try
            {

                var UploadMeterStatus1 = metersDataInput.Status;
                var MeterInstallationDate = metersDataInput.FromDate;


                //SqlBuilder sb = new SqlBuilder(metersDataInput);

                //sb.SetSelectedColoumn("CUploadMainteneceMetersOffReasons.Name1,*");
                //sb.SetTableName(@"CMaintenenceMetersOffs join CUploadMainteneceMetersOffReasons 
                //                  on CUploadMainteneceMetersOffReasons.Id= CMaintenenceMetersOffs.UploadReasonId1 ");
                ////sb.SetJoinColumn("");
                //sb.SetJoinCondition("CUploadMainteneceMetersOffReasons.Id", "CMaintenenceMetersOffs.UploadReasonId1");
                //sb.SetWhere($"CMaintenenceMetersOffs.IsDeleted != 1 and (UploadMeterStatus1 = {UploadMeterStatus1} or UploadMeterStatus1= {UploadMeterStatus1} or UploadMeterStatus1 = {UploadMeterStatus1} or UploadMeterStatus1= {UploadMeterStatus1}) and MeterInstallationDate  >= CONVERT(datetime, '{metersDataInput.FromDate}', 101) and MeterInstallationDate < CONVERT(datetime, '{metersDataInput.ToDate}', 101)  and SmallDepartmentNo in (10,11,12,13,14,15,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,53,90,50,60,70,110,124,99,65,56,58,77,71,78,856,852,63)");
                //string rr = sb.Build();


                if (metersDataInput.Status == 1)
                {
                    metersDataInput.StatusOfMeter = "N'معطل'";
                }
                else if (metersDataInput.Status == 2)
                {
                    metersDataInput.StatusOfMeter = "N'منتهي'";
                }

                else if (metersDataInput.Status == 3)
                {
                    metersDataInput.StatusOfMeter = "N'تالف تماما'";
                }
                else if (metersDataInput.Status == 4)
                {
                    metersDataInput.StatusOfMeter = "N'يحتاج صيانه بالمعمل'";
                }


                ////MeterOffStatusId = {metersDataInput.Status} and




                string query = $@"SELECT dbo.CUploadMainteneceMetersOffReason.Id AS CUploadMainteneceMetersOffReasonID, dbo.CMaintenenceMetersOff.Id AS CMMOiD, dbo.CUploadMainteneceMetersOffReason.Code, dbo.CUploadMainteneceMetersOffReason.Name, 
                  dbo.CUploadMainteneceMetersOffReason.Note, dbo.CMaintenenceMetersOff.VendorCode, dbo.CMaintenenceMetersOff.CustomerCode, dbo.CMaintenenceMetersOff.SerialNumber, dbo.CMaintenenceMetersOff.CustomerName, 
                  dbo.CMaintenenceMetersOff.NationalId, dbo.CMaintenenceMetersOff.Address, dbo.CMaintenenceMetersOff.PlaceTypeId, dbo.CMaintenenceMetersOff.MainDepartmentId, dbo.CMaintenenceMetersOff.SmallDepartmentId, 
                  dbo.CMaintenenceMetersOff.BranchNo, dbo.CMaintenenceMetersOff.AccountNo, dbo.CMaintenenceMetersOff.DailyNo, dbo.CMaintenenceMetersOff.RegionNo, dbo.CMaintenenceMetersOff.MeterPreparedDate, 
                  dbo.CMaintenenceMetersOff.MeterInstallationDate, dbo.CMaintenenceMetersOff.MeterOffDate, dbo.CMaintenenceMetersOff.DeliveryDateToLaboratory, dbo.CMaintenenceMetersOff.IsMeterRecieved, 
                  dbo.CMaintenenceMetersOff.MeterOffReason, dbo.CMaintenenceMetersOff.DeliveryDateToTechnician, dbo.CMaintenenceMetersOff.MaintenanceDate, dbo.CMaintenenceMetersOff.MainDepartmentCode, 
                  dbo.CMaintenenceMetersOff.SmallDepartmentCode, dbo.Section.Name AS SectionName, dbo.ActivityType.Name AS ActivityTypeName, dbo.MainDepartment.Name AS MainDepartmentName, 
                  dbo.SmallDepartment.Name AS SmallDepartmentName, CUploadMainteneceMetersOffReason_1.Name AS ReasonName, dbo.MeterType.Name AS MeterTypeName, dbo.PlaceType.Name AS PlaceTypeName
                  FROM     dbo.CMaintenenceMetersOff INNER JOIN
                  dbo.CUploadMainteneceMetersOffReason ON dbo.CMaintenenceMetersOff.CUploadMainteneceMetersOffReasonId = dbo.CUploadMainteneceMetersOffReason.Id INNER JOIN
                  dbo.Section ON dbo.CMaintenenceMetersOff.SectionId = dbo.Section.Id INNER JOIN
                  dbo.ActivityType ON dbo.CMaintenenceMetersOff.ActivityTypeId = dbo.ActivityType.Id INNER JOIN
                  dbo.MainDepartment ON dbo.CMaintenenceMetersOff.MainDepartmentId = dbo.MainDepartment.Id AND dbo.Section.Id = dbo.MainDepartment.sectionId INNER JOIN
                  dbo.SmallDepartment ON dbo.CMaintenenceMetersOff.SmallDepartmentId = dbo.SmallDepartment.Id AND dbo.Section.Id = dbo.SmallDepartment.SectionId AND 
                  dbo.MainDepartment.Id = dbo.SmallDepartment.MainDepartmentId INNER JOIN
                  dbo.CUploadMainteneceMetersOffReason AS CUploadMainteneceMetersOffReason_1 ON dbo.CMaintenenceMetersOff.CUploadMainteneceMetersOffReasonId = CUploadMainteneceMetersOffReason_1.Id INNER JOIN
                  dbo.MeterType ON dbo.CMaintenenceMetersOff.MeterTypeId = dbo.MeterType.Id LEFT OUTER JOIN
                  dbo.PlaceType ON dbo.CMaintenenceMetersOff.PlaceTypeId = dbo.PlaceType.Id
                  WHERE  (dbo.CMaintenenceMetersOff.IsDeleted <> 1) AND (dbo.CMaintenenceMetersOff.MeterInstallationDate >= CONVERT(datetime, '{metersDataInput.FromDate}', 101)) AND (dbo.CMaintenenceMetersOff.MeterInstallationDate < CONVERT(datetime, '{metersDataInput.ToDate}', 
                  101)) AND (dbo.CMaintenenceMetersOff.SmallDepartmentCode IN (10, 11, 12, 13, 14, 15, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 53, 90, 50, 60, 70, 110, 124, 99, 65, 56, 58, 77, 71, 78, 856, 852, 63))";

                //var steps = _context.Query<CMaintenenceMetersOffDto>(query);

                //var list = _context.cMaintenenceMetersOffDtos.FromSqlRaw(query).ToList();

                using (var connection = _dapperContext.CreateConnection())
                {
                    var model = await connection.QueryAsync<CMaintenenceMetersOffDto>(query);
                    return model.ToList();
                }


               
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
           
        }

        public async Task<TotalMeterOffDto> GetTotalMeterOff(TotalMeterOff TotalMeterOffInput) 
        {
            
            try
            {
                if (TotalMeterOffInput == null || TotalMeterOffInput.FromDate == null || TotalMeterOffInput.ToDate == null)
                    throw new Exception("خطأ فى البيانات المدخلة");

                string query = $@"SELECT ISNULL(DisabledMeters.DisabledMeters, 0) AS DisabledMeters, ISNULL(EndedMeters.EndedMeters, 0) AS EndedMeters, 
                        ISNULL(NotRecivedMeters.NotRecivedMeters, 0) AS NotRecivedMeters, ISNULL(RecivedMeters.RecivedMeters, 0) 
                        AS RecivedMeters, ISNULL(InstalledMeters.InstalledMeters, 0) AS InstalledMeters, ISNULL(NotInstalledMeters.NotInstalledMeters, 0) AS NotInstalledMeters
                        FROM  (SELECT 1 AS ndx, COUNT(0) AS RecivedMeters
                        FROM  dbo.CMaintenenceMetersOff AS CMaintenenceMetersOff_1
                        WHERE (IsMeterRecieved = 1) AND (MeterOffStatusId = 2 or MeterOffStatusId = 1) AND (IsDeleted = 0) 
                        AND (SmallDepartmentCode in (10)) AND (CreationTime >= CONVERT(datetime, '{TotalMeterOffInput.FromDate}', 101))
                        AND (CreationTime <= CONVERT(datetime, '{TotalMeterOffInput.ToDate}', 101))) AS RecivedMeters FULL OUTER JOIN
                        (SELECT 1 AS ndx, COUNT(0) AS InstalledMeters
                        FROM dbo.CMaintenenceMetersOff AS CMaintenenceMetersOff_1
                        WHERE (IsMeterInstalled = 1) AND (MeterOffStatusId = 1) AND (IsDeleted = 0) AND (SmallDepartmentCode in (10)) 
                        AND (CreationTime >= CONVERT(datetime, '{TotalMeterOffInput.FromDate}', 101)) AND (CreationTime <= CONVERT(datetime, '{TotalMeterOffInput.ToDate}', 101))) AS InstalledMeters ON 
                        RecivedMeters.ndx = InstalledMeters.ndx FULL OUTER JOIN (SELECT 1 AS ndx, COUNT(0) AS NotRecivedMeters 
                        FROM dbo.CMaintenenceMetersOff AS CMaintenenceMetersOff_1
                        WHERE   (IsMeterRecieved = 0) AND (MeterOffStatusId != 2 or MeterOffStatusId != 1) AND (IsEnded = 1) 
                        AND (IsDeleted = 0) AND (SmallDepartmentCode in (10)) AND (CreationTime >= CONVERT(datetime, '{TotalMeterOffInput.FromDate}', 101)) 
                        AND (CreationTime <= CONVERT(datetime, '{TotalMeterOffInput.ToDate}', 101))) AS NotRecivedMeters ON RecivedMeters.ndx = NotRecivedMeters.ndx FULL OUTER JOIN
                        (SELECT 1 AS ndx, COUNT(0) AS NotInstalledMeters FROM dbo.CMaintenenceMetersOff AS CMaintenenceMetersOff_1
                        WHERE (IsMeterInstalled = 0) AND ( MeterOffStatusId != 1) AND (IsEnded = 1) AND (IsDeleted = 0)
                        AND (SmallDepartmentCode in (10)) AND (CreationTime >= CONVERT(datetime, '{TotalMeterOffInput.FromDate}', 101)) AND 
                        (CreationTime <= CONVERT(datetime, '{TotalMeterOffInput.ToDate}', 101))) AS NotInstalledMeters ON NotRecivedMeters.ndx = NotInstalledMeters.ndx FULL OUTER JOIN
                        (SELECT 1 AS ndx, COUNT(0) AS EndedMeters FROM  dbo.CMaintenenceMetersOff
                        WHERE   (MeterOffStatusId = 3 or MeterOffStatusId = 1 or MeterOffStatusId = 2)
                        AND (IsDeleted = 0) AND (IsEnded = 1) AND (SmallDepartmentCode in (10)) AND (CreationTime >= CONVERT(datetime, '{TotalMeterOffInput.FromDate}', 101)) 
                        AND (CreationTime <= CONVERT(datetime, '{TotalMeterOffInput.ToDate}', 101))) AS EndedMeters ON NotInstalledMeters.ndx = EndedMeters.ndx FULL OUTER JOIN
                        (SELECT 1 AS ndx, COUNT(0) AS DisabledMeters FROM  dbo.CMaintenenceMetersOff AS CMaintenenceMetersOff_1 WHERE   (MeterOffStatusId = 4) 
                        AND (IsDeleted = 0) AND (SmallDepartmentCode in (10)) AND (CreationTime >= CONVERT(datetime, '{TotalMeterOffInput.FromDate}', 101)) 
                        AND (CreationTime <= CONVERT(datetime, '{TotalMeterOffInput.ToDate}', 101))) AS DisabledMeters ON EndedMeters.ndx = DisabledMeters.ndx
                        WHERE  (ISNULL(DisabledMeters.DisabledMeters, 0) + ISNULL(EndedMeters.EndedMeters, 0) + ISNULL(NotRecivedMeters.NotRecivedMeters, 0) + 
                        ISNULL(RecivedMeters.RecivedMeters, 0) + ISNULL(InstalledMeters.InstalledMeters, 0) + ISNULL(NotInstalledMeters.NotInstalledMeters, 0) > 0);";

                using (var connection = _dapperContext.CreateConnection())
                {
                    var model = await connection.QueryFirstAsync<TotalMeterOffDto>(query);
                    return (TotalMeterOffDto)model;
                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


       
    }
}
