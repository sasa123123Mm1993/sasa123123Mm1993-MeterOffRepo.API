namespace GPICardCore.Master
{
    public class TariffHeader
    {         
         public int tariffId                { get; set; }
         public int? tariffVersion          { get; set; }
         public int? tariffGraceType        { get; set; }
         public int? tariffGracevalue       { get; set; }
         public int? tariffAlarmGrace       { get; set; }
         public int? tariffLimitGrace       { get; set; }
         public int? tariffDeductionGrace   { get; set; }


    }
}
