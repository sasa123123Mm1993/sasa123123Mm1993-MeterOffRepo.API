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

namespace MeterOff.EF.Services
{
    public class ControlCardService : IControlCard
    {
        private readonly DBContext _context;

        public ControlCardService(DBContext context)
        {
            _context = context;
        }

        public IEnumerable<CardFunction> GetAll()
        {
            List<CardFunction> model = _context.CardFunction.ToList();
            return model;
        }

        public IEnumerable<Technician> GetAllTecnicions(int? RegionId, string? filter, int? cardFunctionId)
        {
            List<Technician> model = _context.Technician.ToList();
            return model;
        }

        public InsertControlCardInput AddContolCard(InsertControlCardInput card)
        {

            if (card.MeterSerial != null)
            {
                ValidateMeterSerialNumber(card.MeterSerial);
                ValidateMeterSerialNumberExsit(card.MeterSerial);
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
                .OrderByDescending(a => a.CreationTime).FirstOrDefault(a => a.EmployeeId == card.EmployeeId);

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
                    AccountCode = 100000001

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
                controlCard.ControlCardProperties.Add(new ControlCardManagment() { PropertyId = cardFunction.Id });
            }
            if (cardFunction.Code == 4 || cardFunction.Code == 0 || cardFunction.Code == 10)
            {
                controlCard.StartDate = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
            }

            _context.ControlCard.Add(controlCard);
            _context.SaveChanges();


            var meterType = _context.MeterType //احادى أو ثلاثى
                .FirstOrDefault(m => m.MeterTypeModel == card.MeterTypeModel); // 1 will Replaced with value coming from screen metertype dropdown list
            var generalSettings = _context.DbSetting.FirstOrDefault();


            #region Build XML
            ControlCardBuilder contrlCardBuilder = new ControlCardBuilder();
            contrlCardBuilder.SetMeterType("0");
            contrlCardBuilder.SetMeterVersion("GPM-PP01");
            contrlCardBuilder.SetManufacturerId("07");
            contrlCardBuilder.SetCardId("111");
            contrlCardBuilder.SetDistributionCompanyCode("5");
            contrlCardBuilder.SetCardPeriod(new CardPeriod
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
                case 3:
                    var tamperCodeList = card.TampersCodes.Select(int.Parse).ToList();
                    xmlResult = contrlCardBuilder.BuildClearTamperCard(tamperCodeList); //under Test
                    break;
                case 4:
                    xmlResult = contrlCardBuilder.BuildResetCard();
                    break;

                case 5:
                    xmlResult = contrlCardBuilder.BuildToggleRelayCard();
                    break;
                case 6:
                    xmlResult = contrlCardBuilder.BuildRelayTestCard(); //under Test
                    break;

                //case 7: 
                //    xmlResult = contrlCardBuilder.BuildAlterTariffCard();
                //    break;

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
                    xmlResult = contrlCardBuilder.BuildChangeCompanyCodeCard(card.NewDistributionCompanyCode);
                    break;
                case 51:
                    xmlResult = contrlCardBuilder.BuildChangeMeterNumberCard(card.OldMeterSerial, card.NewMeterSerial);
                    break;
                    //case 53:
                    //    xmlResult = contrlCardBuilder.BuildCustomerCard();
                    //    break;


 
            }
            #endregion

            var cardsetting = _context.BasicSetting.FirstOrDefault();
            cardsetting.CardNumber += 1;
            _context.BasicSetting.Update(cardsetting);
            _context.ControlCard.Add(controlCard);
            _context.Add(card);
            _context.SaveChanges();
            return card;
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
                throw new UserFriendlyException("هذا العداد غير موجود بالنظام ");
            }
            return flag;
        }




    }
}
