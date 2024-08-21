using System.Xml.Serialization;

namespace GPICardCore.Master
{
    public class TariffsDetails
    {
          public int TariffId { get; set; }

         public string TariffGraceType { get; set; }

         public string TariffGraceValue { get; set; }

         public string TariffAlarmGrace { get; set; }

         public string TariffLimitGrace { get; set; }

         public string TariffDeductionGrace { get; set; }

         public List<TariffDetails> TariffDetailsList { get; set; }
    }


}
