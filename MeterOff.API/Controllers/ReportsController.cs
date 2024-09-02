using Asp.Versioning;
using AutoMapper;
using GPICardDB;
using MeterOff.Core.Interfaces;
using MeterOff.Core.Models.Base;
using MeterOff.Core.Models.Dto.Reports;
using MeterOff.Core.Models.Enum;
using MeterOff.Core.Models.Infrastructure;
using MeterOff.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;

namespace MeterOff.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    //[ApiVersion("1.0")]
    //[Route("v{version:apiVersion}/api/[Controller]/[action]")]

    public class ReportsController : ControllerBase
    {
        //private readonly DBContext _context;
        private readonly IMapper _mapper;
        private readonly IReport _report;
        public ReportsController(IMapper mapper,IReport report)
        {
                _mapper = mapper;
              _report = report;
        }

        [HttpPost("GetAll")]
        public  IActionResult GetAllData(MetersDataInput metersDataInput)
        {
            //var data = await _report.GetAllData();
            //var data = _mapper.Map<IEnumerable<CMaintenenceMetersOffOutput>>(MaintenenceMeters);
            //return StatusCode(200, MaintenenceMeters);

            var model = new MetersDataInput();
            return (IActionResult)model;

        }



    }
}
