using GPICardCore;
using MeterOff.Core.Models;
using MeterOff.Core.Interfaces;
using MeterOff.Core.Models.Dto.ControlCard;
using MeterOff.Core.Models.Enum;
using MeterOff.Core.Models.Exception;
using MeterOff.Core.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPICardCore.Master;
using GPICardDB;
using MeterOff.Core.Models.Dto.Reports;
using MeterOff.Core.Models.Dto.CardFunctionDto;
using MeterOff.Core.Models.Dto.CMaintenenceMetersOff;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using MeterOff.Core.Models.Base;
using MeterOff.API.ErrorHandeling;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using MeterOff.Core.Models.Dto.UserDto;
using MeterOff.Core.Models.Base_Response.Providers;
using Dapper;
using System.Drawing;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MeterOff.EF.Services
{
    public class ControlCardService : IControlCard
    {
        private readonly DBContext _context;
        private readonly DapperContext _dapperContext;

        public ControlCardService(DBContext context, DapperContext dapperContext)
        {
            _context = context;
            _dapperContext = dapperContext;
        }
        public Response<List<CardFunctionDto>> GetAll()
        {

            Response<List<CardFunctionDto>> response = new Response<List<CardFunctionDto>>();
            try
            {
                var cardFunctions = _context.CardFunction.Where(r => r.IsDeleted != true)
                  .Select(k => new CardFunctionDto
                  { Code = k.Code, Name = k.Name, }).ToList();

                if (cardFunctions != null && cardFunctions.Any())
                {
                    response.payload = cardFunctions;
                    response.code = Success.Code;
                    response.status = Success.Status;
                    response.message = Success.messageAr;
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.code = GeneralException.Code;
                response.message = GeneralException.messageAr;
                response.status = ex.Message;
                response.payload = null;
                return response;
            }
            response.code = Empty.Code;
            response.message = Empty.messageAr;
            response.status = Empty.Status;
            response.payload = null;
            return response;
        }
        public Response<List<Technician>> GetAllTecnicions(int? RegionId, string? filter, int? cardFunctionId)
        {
            Response<List<Technician>> response = new Response<List<Technician>>();
            try
            {
                var regionId = (RegionId == null) ? null : RegionId;
                var name = (filter == null) ? null : filter;
                var technicianTypeId = (cardFunctionId == null) ? null : cardFunctionId;

                //string RegionId_where = (RegionId == null) ? "" : $@" dbo.Technician.RegionId = {RegionId} OR ";
                //string name_where = (filter == null) ? "" : $@"  dbo.Technician.Name = {filter} OR ";
                //string TechnicianTypeId_where = (cardFunctionId == null) ? "" : $@"  dbo.Technician.TechnicianTypeId = {cardFunctionId} AND";

                //string techinicians = $@" SELECT * FROM dbo.Technician WHERE " + RegionId_where + name_where + TechnicianTypeId_where + "dbo.Technician.IsDeleted <> 1";

                var techinicians = _context.Technician.Where(t => t.RegionId == regionId
                               || t.Name == name || t.TechnicianTypeId == technicianTypeId || t.IsDeleted != true).ToList();

                if (techinicians != null && techinicians.Any())
                {
                    response.code = Success.Code;
                    response.status = Success.Status;
                    response.message = Success.messageAr;
                    response.payload = techinicians;
                    //using (var connection = _dapperContext.CreateConnection())
                    //{
                    //    var model = connection.Query<Technician>(techinicians);
                    //    foreach (var item in model)
                    //    {
                    //        response.payload.Add(new Technician
                    //        {
                    //            BirthDate = item.BirthDate,
                    //            CreationTime = item.CreationTime,
                    //            CreatorById = item.CreatorById,
                    //            HireDate = item.HireDate,
                    //            Id = item.Id,
                    //            Name = item.Name,
                    //            IsActive = item.IsActive,
                    //            IsCompanyCardPrivilidge = item.IsCompanyCardPrivilidge,
                    //            IsDeleted = item.IsDeleted,
                    //            IsDepartmentUpdate = item.IsDepartmentUpdate,
                    //            IsEmployeeNew = item.IsEmployeeNew
                    //        });

                    //    }

                    //}
                    return response;
                }

                if (techinicians == null || techinicians.Count == 0)
                {

                    response.code = Empty.Code;
                    response.message = Empty.messageEn;
                    response.status = Empty.Status;
                    response.payload = null;
                    return response;
                }
                response.code = Failed.Code;
                response.message = Failed.messageEn;
                response.status = Failed.Status;
                response.payload = null;
                return response;
            }
            catch (Exception ex)
            {
                response.code = GeneralException.Code;
                response.message = GeneralException.messageAr;
                response.status = ex.Message;
                response.payload = null;
                return response;
            }
           
        }
        public Response<ControlCardOutput> AddContolCard(InsertControlCardInput card)
        {
            Response<ControlCardOutput> response = new Response<ControlCardOutput>();
            try
            {
                
                var result =  ValidAddContolCard(card);
                if (result.status !=null)
                {
                    var cardFunction = _context.CardFunction.FirstOrDefault(m => m.Code == card.PropertyId);
                    var technician = _context.Technician.FirstOrDefault(m => m.Id == card.EmployeeId); // الفنى
                    if (technician != null)
                    {
                        if (!technician.IsActive)
                        {
                            throw new UserFriendlyException("لايمكن اصدار الكارت لأن هذا الفنى محظور");
                        }

                        if (card.PropertyId != 2 && technician.technicianTypes.Code == "3")
                        {
                            throw new UserFriendlyException("لايمكن اصدار الكارت لأن هذا الفنى كشاف");
                        }
                        if (card.PropertyId == 2 && technician.technicianTypes.Code == "4")
                        {
                            throw new UserFriendlyException("لايمكن اصدار الكارت لأن هذا الفنى ليس كشاف");
                        }
                    }
                    var lastCardFortechnician = _context.ControlCard
                        .OrderByDescending(a => a.CreationTime)
                        .FirstOrDefault(a => a.EmployeeId == card.EmployeeId);
                    if (cardFunction != null)
                    {
                        if (lastCardFortechnician != null)
                        {
                            var sameCardProperties = _context.ControlCardManagment
                                .Where(m => m.PropertyId == cardFunction.Id && m.ControlCarId == lastCardFortechnician.Id)
                                .FirstOrDefault();
                            if (sameCardProperties != null)
                            {
                                lastCardFortechnician.IsBlocked = true;
                                _context.SaveChanges();
                            }
                        }
                    }
                    var cardSetting = _context.BasicSetting.FirstOrDefault();
                    if (cardSetting != null)
                    {
                        cardSetting.CardNumber += 1;
                        _context.BasicSetting.Update(cardSetting);
                    }
                    else
                    {
                        cardSetting = new BasicSetting()
                        {
                            CardNumber = 100000000000001,
                            AccountCode = 100000001,
                            MFPCode = "1", // change it with migration to accept null value

                        };
                        _context.BasicSetting.Add(cardSetting);
                    }
                    var controlCard = new ControlCard()
                    {
                        EmployeeId = card.EmployeeId, // From DropDown
                        StartDate = card.StartDate.GetFormateDateTimeFromString(),
                        ExpirationDate = card.ExpirationDate.GetFormateDateTimeFromString(),
                        Limitation = card.Limitation,
                        CardId = cardSetting.CardNumber.ToString(),
                        MeterSerial = card.MeterSerial,
                        CreationTime = DateTime.Now,
                    };
                    if (cardFunction != null)
                    {
                        controlCard.ControlCardProperties.Add(new ControlCardManagment()
                        { PropertyId = cardFunction.Id });
                    }
                    if (cardFunction.Code == 4 || cardFunction.Code == 0 || cardFunction.Code == 10)
                    {
                        controlCard.StartDate = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
                    }
                    _context.ControlCard.Add(controlCard);
                    _context.SaveChanges();
                    var newControlCardId = _context.ControlCard.OrderByDescending(m => m.Id).FirstOrDefault().CardId;
                    var meterType = _context.MeterType //احادى أو ثلاثى
                        .FirstOrDefault(m => m.MeterTypeModel == card.MeterTypeModel); // 1 will Replaced with value coming from screen metertype dropdown list
                    var generalSettings = _context.DbSetting.FirstOrDefault();

                    #region Build XML
                    ControlCardBuilderXml contrlCardBuilder = new ControlCardBuilderXml();
                    List<string> selectedMetersList = card.ControledMetersList?.ToList<string>() ?? new List<string>();
                    if (selectedMetersList.Any())
                    {
                        contrlCardBuilder.SetSelectedMeters(selectedMetersList);
                    }
                    contrlCardBuilder.SetMeterType(0)
                    .SetMeterVersion(DB.GetMeterVersion(1))
                    .SetManufacturerId(DB.GetManufacturerId())
                    .SetCardId(newControlCardId)
                    .SetDistributionCompanyCode("5")
                    .SetCardPeriod(new ControlCardActivationPeriod
                    {
                        ActivationDate = DateTime.Now.ToString("dd-MM-yyyy"),
                        ExpiryDate = DateTime.Now.AddDays(99).ToString("dd-MM-yyyy")
                    });
                    if (technician.LevelEnum == LevelEnum.Company || technician.LevelEnum == LevelEnum.Section)
                    {
                        contrlCardBuilder.SetSectorCode("0");
                    }
                    else contrlCardBuilder.SetSectorCode(technician.SmallDepartments.FirstOrDefault().RegionCode.ToString());

                    var xmlResult = "";

                    switch (card.PropertyId)
                    {
                        case 0: //
                            xmlResult = contrlCardBuilder.BuildSetDateTimeCard(DateTime.Now);
                            break;
                        case 1: // نقل بيانات عداد
                            if (card.MeterSerial != null)
                            {
                                var meterSerialExist = _context.MeterData.Any(m => m.SerialNumber == card.MeterSerial);
                                if (meterSerialExist)
                                {
                                    xmlResult = contrlCardBuilder.BuildCopyMeterCard(card.MeterSerial);
                                    break;
                                }
                                else
                                {
                                    throw new Exception("No Meter Found With This Serial Number");
                                }
                            }
                            else
                            {
                                throw new Exception("You Must Enter Serial Number");
                            }

                        case 2: //تجميع قراءات
                            xmlResult = contrlCardBuilder.BuildCollectCard();
                            break;
                        case 3:
                            var tamperCodeList = card.TampersCodes.Select(int.Parse).ToList();
                            xmlResult = contrlCardBuilder.BuildClearTamperCard(tamperCodeList);
                            break;
                        case 4:
                            xmlResult = contrlCardBuilder.BuildResetMeterCard();
                            break;

                        case 5:
                            xmlResult = contrlCardBuilder.BuildToggleRelayCard(Convert.ToInt32(card.ReverseCardRecoveryTime));
                            break;
                        case 6:
                            xmlResult = contrlCardBuilder.BuildRelayTestCard();
                            break;

                        case 7:
                            var tariffHeader = new TariffHeader
                            {
                                tariffId = (int)card.TariffTypeId
                            };
                            xmlResult = contrlCardBuilder.BuildAlterTariffCard(GPICardDB.DB.GetTariffStep((int)card.TariffTypeId), tariffHeader,
                                DB.GetZeroConsumptionFeeAmount((int)card.TariffTypeId));
                            break;

                        case 8:
                            var balanceAlarmCutoffLimitsList = new List<int>();
                            var template = _context.SettingFormsData.FirstOrDefault();
                            if (template != null)
                            {
                                balanceAlarmCutoffLimitsList.Add(Convert.ToInt32(template.FirstCutoffAlarmLimitBalance));
                                balanceAlarmCutoffLimitsList.Add(Convert.ToInt32(template.SecondCutoffAlarmLimitBalance));
                            }
                            xmlResult = contrlCardBuilder.BuildAlarmCutoffLimitsCard(balanceAlarmCutoffLimitsList);
                            break;

                        case 10:
                            xmlResult = contrlCardBuilder.BuildSetDateTimeOnMeterManualCard();
                            break;
                        case 11:
                            xmlResult = contrlCardBuilder.BuildLunchCurrentCard(); //under Test
                            break;

                        case 50:
                            xmlResult = contrlCardBuilder.BuildChangeDistributionCompanyCodeCard(card.NewDistributionCompanyCode);
                            break;
                        case 51:
                            xmlResult = contrlCardBuilder.BuildChangeMeterNumberCard(card.OldMeterSerial, card.NewMeterSerial);
                            break;
                        case 53:
                            var tamperList = card.TampersCodes.Select(int.Parse).ToList(); //اصدار كارت المعمل
                            var convertedLabTamperList = ConvertList(tamperList);
                            xmlResult = contrlCardBuilder.BuildLabCard(convertedLabTamperList, card.LabTestCardAvailableKWh.ToInt(), card.LabTestCardAvailableTime.ToInt());
                            break;

                    }
                    #endregion


                    var cardsetting = _context.BasicSetting.FirstOrDefault();
                    cardsetting.CardNumber += 1;
                    _context.BasicSetting.Update(cardsetting);
                    //_context.ControlCard.Add(controlCard);
                    //_context.Add(card);
                    _context.SaveChanges();

                    response.code = Added.Code;
                    response.payload = new ControlCardOutput
                    {
                        ControlCardId = newControlCardId,
                        Payload = xmlResult.Encrypt()
                    };
                    response.status = Success.Status;
                    response.message = "تم انشاء الكارت بنجاح";
                    return response;
                }

                else
                {
                    response.code = Failed.Code;
                    response.message = Failed.messageEn;
                    response.status = Failed.Status;
                    response.payload = null;
                    return response;
                }
            }

           
            catch (Exception ex)
            {
                response.code = GeneralException.Code;
                response.message = GeneralException.messageAr;
                response.status = ex.Message;
                response.payload = null;
                return response;
            }
            

        }
        public Response<string> ValidAddContolCard(InsertControlCardInput card)
        {
            Response<string> response = new Response<string>
            {
                code = Empty.Code,
                status = Empty.Status
            };
            if (card.MeterSerial == null)
            {
                response.status = EmptyMember.Status;
                response.code = EmptyMember.Code;
                response.message = "من فضلك ادخل رقم العداد";
                response.payload = EmptyMember.messageEn;
                return response;
            }

            if (card.MeterSerial != null)
            {
                ValidateMeterSerialNumber(card.MeterSerial);
                ValidateMeterSerialNumberExsit(card.MeterSerial);
            }

            if (card.EmployeeId == null)
            {
                response.status = EmptyMember.Status;
                response.code = EmptyMember.Code;
                response.message = "من فضلك ادخل فنى ";
                response.payload = EmptyMember.messageEn;
                return response;
            }
            if (card.EmployeeId != null)
            {
                ValidateTechnicianExist(card.EmployeeId);
            }

            return response;

        }
        public bool ValidateMeterSerialNumber(string meterSerialNumber)
        {
            var output = true;
            if (!string.IsNullOrEmpty(meterSerialNumber))
            {
                int serial = Convert.ToInt32(meterSerialNumber);

                var result = _context.SettingFormsData.FirstOrDefault();
                if (result != null)
                {
                    if (serial < result.MeterSerialFrom || serial > result.MeterSerialTo)
                        output = false;
                }
            }
            return output;
        }
        public int ValidateMeterSerialNumberExsit(string serialNumber)
        {
            var flag = 0;
            var meter = _context.MeterData.FirstOrDefault(a => a.SerialNumber == serialNumber);
            if (meter != null)
            {
                if (meter.Status == MeterStatusEnum.maintenance ||
                    meter.Status == MeterStatusEnum.InStock ||
                    meter.Status == MeterStatusEnum.damage)
                    flag = 1;
            }
            else
            {
                flag = 2;
                throw new BusinessException("هذا العداد غير موجود بالنظام ", "6002");
            }
            return flag;
        }

      
        public int ValidateTechnicianExist(int emplyeeId)
        {
            var flag = 0;
            var technician = _context.Technician.FirstOrDefault(a => a.Id == emplyeeId);
            if (technician != null)
            {
                flag = 1;
            }
            else
            {
                flag = 2;
                throw new BusinessException("هذا الفنى غير موجود بالنظام ", "6003");
            }
            return flag;
        }
        public Response<DateTime> GetTechinicianExpirationDate()
        {
            Response<DateTime> response = new Response<DateTime>();
            try
            {
                var serverDate = DateTime.Now;
                response.code = Success.Code;
                response.message = "";
                response.status = Success.Status;
                response.payload = serverDate.AddDays(7);
                return response;

            }
            catch (Exception ex)
            {
                response.code = GeneralException.Code;
                response.message = GeneralException.messageAr;
                response.status = ex.Message;
                response.payload = DateTime.Now;
                return response;
            }
        }
        public Response<DateTime> GetTechinicianActivationDate()
        {
            Response<DateTime> response = new Response<DateTime>();
            try
            {
                var serverDate = DateTime.Now;
                response.code = Success.Code;
                response.message = "";
                response.status = Success.Status;
                response.payload = serverDate;
                return response;

            }
            catch (Exception ex)
            {
                response.code = GeneralException.Code;
                response.message = GeneralException.messageAr;
                response.status = ex.Message;
                response.payload = DateTime.Now;
                return response;
            }
        }

        public Response<bool> CancelControlCard(string controlCardId)
        {
            Response<bool> response = new Response<bool>();
            try
            {
                var controlCard = _context.ControlCard.FirstOrDefault(m=>m.CardId == controlCardId);
                if (controlCard == null)
                {
                    response.code = EmptyMember.Code;
                    response.message = "رقم الكارت غير موجود بالنظام";
                    response.status = EmptyMember.Status;
                    response.payload = false;
                    return response;
                }
                if (controlCard.IsDeleted == true)
                {
                    response.code = EmptyMember.Code;
                    response.message = "الكارت ممسوح بالفعل";
                    response.status = EmptyMember.Status;
                    response.payload = false;
                    return response;
                }

                else
                {
                    controlCard.IsDeleted = true;
                    _context.Update(controlCard);
                    var ISSaved = Save() > 0;
                    if (ISSaved)
                    {
                        response.code = DeleteSuccess.Code;
                        response.payload = ISSaved;
                        response.status = DeleteSuccess.Status;
                        response.message = DeleteSuccess.messageAr;
                        return response;
                    }
                }

                response.code = Failed.Code;
                response.message = "حدث خطا أثناء حذف معلومات العميل";
                response.status = Failed.Status;
                response.payload = false;
                return response;
            }
            catch (Exception ex)
            {
                response.code = GeneralException.Code;
                response.message = GeneralException.messageAr;
                response.status = ex.Message;
                response.payload = false;
                return response;
            }
        }

        public Response<ControlLaunchOutput> ReadControlLaunch()
        {
            throw new NotImplementedException();
        }

        static List<int> ConvertList(List<int> inputList)
        {
            return inputList
                .Select(x => x == 1 ? 6 : x == 2 ? 7 : x)
                .ToList();
        }

        public Response<List<Tamper>> GetAllTempers()
        {
            Response<List<Tamper>> response = new Response<List<Tamper>>();
            try
            {
                var model = _context.Tamper.Where(t => t.Code != "0" & t.Code != "9" & t.IsDeleted !=true).ToList();

                if (model != null && model.Any())
                {
                    response.payload = model;
                    response.code = Success.Code;
                    response.status = Success.Status;
                    response.message = Success.messageAr;
                    return response;
                }
                if (model == null || model.Count == 0)
                {

                    response.code = Empty.Code;
                    response.message = Empty.messageEn;
                    response.status = Empty.Status;
                    response.payload = null;
                    return response;
                }
                response.code = Failed.Code;
                response.message = Failed.messageEn;
                response.status = Failed.Status;
                response.payload = null;
                return response;
            }
            catch (Exception ex)
            {
                response.code = GeneralException.Code;
                response.message = GeneralException.messageAr;
                response.status = ex.Message;
                response.payload = null;
                return response;
            }
           
        }

        public int Save()
        {
            int status = -1;
            try { status = _context.SaveChanges(); }
            catch (Exception ex) { }
            return status;
        }
    }
}
