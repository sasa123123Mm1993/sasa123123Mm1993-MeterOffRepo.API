namespace GPICardCore.Master
{
    public class TariffDetails
    {
       
         public int TariffId { get; set; }

         public int? TariffGraceType { get; set; }

         public int? TariffGracevalue { get; set; }

         public int? TariffAlarmGrace { get; set; }

         public int? TariffLimitGrace { get; set; }

         public int? TariffDeductionGrace { get; set; }

      
        public List<TariffStep> TariffSteps { get; set; }
    }


}
