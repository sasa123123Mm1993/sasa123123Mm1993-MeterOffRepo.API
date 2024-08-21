using System.Xml.Serialization;

namespace GPICardCore.Master
{
    public class LastRechargeDetails
    {
         public int RechargeSequence { get; set; }

         public decimal RechargeAmount { get; set; }

         public string RechargeTime { get; set; }
    }
}
