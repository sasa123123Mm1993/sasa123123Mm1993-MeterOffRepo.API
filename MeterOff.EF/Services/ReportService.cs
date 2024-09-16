using Dapper;
using MeterOff.Core.Interfaces;
using MeterOff.Core.Models.Base;
using MeterOff.Core.Models.Dto.Reports;
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


                string query = $@"SELECT dbo.CUploadMainteneceMetersOffReason.Id AS CUploadMainteneceMetersOffReasonID, dbo.CMaintenenceMetersOff.Id AS CMMOiD, dbo.CUploadMainteneceMetersOffReason.Code, dbo.CUploadMainteneceMetersOffReason.Name, 
                  dbo.CUploadMainteneceMetersOffReason.Note, dbo.CMaintenenceMetersOff.VendorCode, dbo.CMaintenenceMetersOff.CustomerCode, dbo.CMaintenenceMetersOff.SerialNumber, dbo.CMaintenenceMetersOff.CustomerName, 
                  dbo.CMaintenenceMetersOff.NationalId, dbo.CMaintenenceMetersOff.Address, dbo.CMaintenenceMetersOff.PlaceTypeId, dbo.CMaintenenceMetersOff.ActivityTypeId, dbo.CMaintenenceMetersOff.SectionId, 
                  dbo.CMaintenenceMetersOff.MainDepartmentId, dbo.CMaintenenceMetersOff.SmallDepartmentId, dbo.CMaintenenceMetersOff.BranchNo, dbo.CMaintenenceMetersOff.AccountNo, dbo.CMaintenenceMetersOff.DailyNo, 
                  dbo.CMaintenenceMetersOff.RegionNo, dbo.CMaintenenceMetersOff.MeterPreparedDate, dbo.CMaintenenceMetersOff.MeterInstallationDate, dbo.CMaintenenceMetersOff.MeterOffDate, 
                  dbo.CMaintenenceMetersOff.DeliveryDateToLaboratory, dbo.CMaintenenceMetersOff.IsMeterRecieved, dbo.CMaintenenceMetersOff.MeterOffReason, dbo.CMaintenenceMetersOff.DeliveryDateToTechnician, 
                  dbo.CMaintenenceMetersOff.MaintenanceDate, dbo.CMaintenenceMetersOff.MainDepartmentCode, dbo.CMaintenenceMetersOff.SmallDepartmentCode
                  FROM  dbo.CMaintenenceMetersOff INNER JOIN
                  dbo.CUploadMainteneceMetersOffReason ON dbo.CMaintenenceMetersOff.CUploadMainteneceMetersOffReasonId = dbo.CUploadMainteneceMetersOffReason.Id
                    WHERE CMaintenenceMetersOff.IsDeleted != 1  and
                    MeterOffStatusId = {metersDataInput.Status} and
                    MeterInstallationDate >= CONVERT(datetime, '{metersDataInput.FromDate}', 101) and
                    MeterInstallationDate < CONVERT(datetime, '{metersDataInput.ToDate}', 101) and
                    SmallDepartmentCode in (10, 11, 12, 13, 14, 15, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26,
                    27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 53, 90, 50, 60, 70, 110, 124,
                    99, 65, 56, 58, 77, 71, 78, 856, 852, 63);";

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


    }
}
