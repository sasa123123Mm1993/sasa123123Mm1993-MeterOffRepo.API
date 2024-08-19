using Asp.Versioning;
using AutoMapper;
using MeterOff.Core.Models.Base;
using MeterOff.Core.Models.Infrastructure;
using MeterOff.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace MeterOff.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    //[ApiVersion("1.0")]
    //[Route("v{version:apiVersion}/api/[Controller]/[action]")]

    public class ReportsController : ControllerBase
    {
        private readonly DBContext _context;
        private readonly IMapper _mapper;
        //private readonly IReport _report;

        [HttpPost("GetAll")]
        public IActionResult GetAll(MetersDataInput metersDataInput)
        {
            try
            {
                var parameters = new
                {
                    UploadMeterStatus1 = metersDataInput.Status,
                    MeterInstallationDate = metersDataInput.FromDate,

                };
                SqlBuilder sb = new SqlBuilder(metersDataInput);

                sb.SetSelectedColoumn("CUploadMainteneceMetersOffReasons.Name1,*");
                sb.SetTableName(@"CMaintenenceMetersOffs join CUploadMainteneceMetersOffReasons 
                                  on CUploadMainteneceMetersOffReasons.Id= CMaintenenceMetersOffs.UploadReasonId1 ");
                //sb.SetJoinColumn("");
                sb.SetJoinCondition("CUploadMainteneceMetersOffReasons.Id", "CMaintenenceMetersOffs.UploadReasonId1");
                sb.SetWhere($"CMaintenenceMetersOffs.IsDeleted != 1 and (UploadMeterStatus1 = {parameters.UploadMeterStatus1} or UploadMeterStatus1= {parameters.UploadMeterStatus1} or UploadMeterStatus1 = {parameters.UploadMeterStatus1} or UploadMeterStatus1= {parameters.UploadMeterStatus1}) and MeterInstallationDate  >= CONVERT(datetime, '{metersDataInput.FromDate}', 101) and MeterInstallationDate < CONVERT(datetime, '{metersDataInput.ToDate}', 101)  and SmallDepartmentNo in (10,11,12,13,14,15,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,53,90,50,60,70,110,124,99,65,56,58,77,71,78,856,852,63)");

                string rr = sb.Build();




                //string query = "select Top 1 * From Charges where AccountId=" + accountId + "order by  TransactionDate DESC";



                string query = $@"select CUploadMainteneceMetersOffReasons.Name1,* 
                                from CMaintenenceMetersOffs join CUploadMainteneceMetersOffReasons on CUploadMainteneceMetersOffReasons.Id= CMaintenenceMetersOffs.UploadReasonId1 
                                WHERE CMaintenenceMetersOffs.IsDeleted != 1 and (UploadMeterStatus1= @UploadMeterStatus1)and MeterInstallationDate @MeterInstallationDate and SmallDepartmentNo in (@SmallDepartmentNo);";
                var list = _context.cMaintenenceMetersOffDtos.FromSqlRaw(query).ToList();
                return (IActionResult)list;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            //if (metersDataInput == null)
            //var data = _report.GetAll(metersDataInput).ToList();
            //return StatusCode(200, data);

        }

    }
}
