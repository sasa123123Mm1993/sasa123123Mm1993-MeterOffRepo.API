﻿

namespace GPICardCore.Master
{
    public class TariffStep
    {
         public decimal TariffStepCustomerServiceFee { get; set; }

         public int TariffStepLimitFrom { get; set; }

         public int TariffStepLimitTo { get; set; }
         public int TariffStepNumber { get; set; }

         public decimal TariffStepPrice { get; set; }
         public decimal? TariffStepRecalculationEdge { get; set; }
         public decimal? TariffStepRecalculationEdgeAddedAmount { get; set; }

      

        //public TariffStep(decimal customerServiceFee, int limitFrom, int limitTo, int stepNumber, decimal price, decimal? recalculationEdge = null, decimal? recalculationEdgeAddedAmount = null)
        //{
        //    TariffStepCustomerServiceFee = customerServiceFee;
        //    TariffStepLimitFrom = limitFrom;
        //    TariffStepLimitTo = limitTo;
        //    TariffStepNumber = stepNumber;
        //    TariffStepPrice = price;
        //    TariffStepRecalculationEdge = recalculationEdge;
        //    TariffStepRecalculationEdgeAddedAmount = recalculationEdgeAddedAmount;
        //}

    }
}
