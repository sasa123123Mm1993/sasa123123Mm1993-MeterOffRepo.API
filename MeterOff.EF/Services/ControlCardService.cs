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

namespace MeterOff.EF.Services
{
    public class ControlCardService : IControlCard
    {
        private readonly DBContext _context;
        

        public ControlCardService(DBContext context)
        {
            _context = context;
            
        }

        public async Task<IEnumerable<CardFunctionDto>> GetAll()
        {
            var model = _context.CardFunction
                  .Select(k => new CardFunctionDto
                  {Code = k.Code,Name = k.Name,}).ToList();

                 return model;


        }

        public IEnumerable<Technician> GetAllTecnicions(int? RegionId, string? filter, int? cardFunctionId)
        {
            List<Technician> model = _context.Technician.ToList();
            return model;
        }

        public ControlCardOutput AddContolCard(InsertControlCardInput card)
        {
            try
            {
                if (card.MeterSerial != null)
                {
                    ValidateMeterSerialNumber(card.MeterSerial);
                    ValidateMeterSerialNumberExsit(card.MeterSerial);
                }

                if (card.EmployeeId !=null)
                {
                    ValidateTechnicianExist(card.EmployeeId);
                }
                
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
                ControlCardBuilder contrlCardBuilder = new ControlCardBuilder();

                List<string> selectedMetersList = card.ControledMetersList?.ToList<string>() ?? new List<string>();

                if (selectedMetersList.Any())
                {
                    contrlCardBuilder.SetSelectedMeters(selectedMetersList);
                }


                contrlCardBuilder.SetMeterType(0);
                contrlCardBuilder.SetMeterVersion(DB.GetMeterVersion(1));
                contrlCardBuilder.SetManufacturerId(DB.GetManufacturerId());
                //contrlCardBuilder.SetCardId(newControlCardId);
                contrlCardBuilder.SetDistributionCompanyCode("5");
                contrlCardBuilder.SetCardPeriod(new ControlCardActivationPeriod
                {
                    ActivationDate = DateTime.Now,
                    ExpiryDate = DateTime.Now.AddDays(99)
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
                        if(card.MeterSerial != null) 
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
                        xmlResult = contrlCardBuilder.BuildResetCard();
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

                var output = new ControlCardOutput
                {
                    Payload = xmlResult.Encrypt(),
                    ControlCardId = newControlCardId
                };

                return output;


            }
            catch (UserFriendlyException ex)
            {
                if (ex.Message !=null)
                throw new UserFriendlyException(ex.Message, ex.Message, ex.Code);
               else throw new UserFriendlyException(ex.InnerException.Message);
            }
            


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
                throw new UserFriendlyException("هذا العداد غير موجود بالنظام ","",6002);
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
                throw new UserFriendlyException("هذا الفنى غير موجود بالنظام ","",6003);
            }
            return flag;
        }

       

        public DateTime GetTechinicianExpirationDate()
        {
            var serverDate = DateTime.Now;
            return serverDate.AddDays(7); ;
        }

        public DateTime GetTechinicianActivationDate()
        {
            var serverDate = DateTime.Now;
            return serverDate;
        }

        public PayLoad<DeleteResult> CancelControlCard(string controlCardId)
        {
            var model = _context.ControlCard.FirstOrDefault(m=>m.CardId == controlCardId);
            if (model == null)
                
                  throw new BusinessException("رقم الكارت غير موجود بالنظام","1000");

            if (model.IsDeleted == true)
            {
                throw new BusinessException("الكارت ممسوح بالفعل", "1001");
            }

            if (model !=null)
            {
                model.IsDeleted = true;
                _context.SaveChanges();
                var successPayloadDto = new PayLoad<DeleteResult>
                {
                    Success = true,
                    Model = null,
                    Code = 200,
                    Errors = null,
                    Message = "Deleted Successfully",
                    
                };
                return successPayloadDto;
            }
            
            else {
                var failedPayloadDto = new PayLoad<DeleteResult>
                {
                    Success = false,
                    Model = null,
                    Code = 6000,
                    Errors = null,
                    Message = "Request failed"
                    
                };
                return failedPayloadDto;
            }
        }
        public ControlLaunchOutput ReadControlLaunch()
        {
            throw new NotImplementedException();
        }


        static List<int> ConvertList(List<int> inputList)
        {
            return inputList
                .Select(x => x == 1 ? 6 : x == 2 ? 7 : x)
                .ToList();
        }

        public IEnumerable<Tamper> GetAllTempers()
        {
            var model = _context.Tamper.Where(t=>t.Code !="0" & t.Code !="9").ToList();
            return model;
        }


    }
}
