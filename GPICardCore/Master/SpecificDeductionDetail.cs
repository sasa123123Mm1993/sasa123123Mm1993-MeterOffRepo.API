namespace GPICardCore.Master
{

    public class SpecificDeductionDetail
    {
        public int StepNumber { get; set; }
         public int Limit { get; set; }
        public decimal Price { get; set; }

        public SpecificDeductionDetail(int stepNumber, int deductionLimit, decimal deductionPrice)
        {
            StepNumber = stepNumber;
            Limit = deductionLimit;
            Price = deductionPrice;
        }
    }
}
