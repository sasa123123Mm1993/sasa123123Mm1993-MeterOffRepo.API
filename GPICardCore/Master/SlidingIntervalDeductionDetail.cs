using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GPICardCore.Master
{
    public class SlidingIntervalDeductionDetail
    {
        public int Number { get; set; }
        public int LimitFrom { get; set; }
        public int LimitTo { get; set; }
        public decimal Price { get; set; }

        public SlidingIntervalDeductionDetail(int number , int limitFrom, int limitTo, decimal price)
        {
            Number = number ; 
            LimitFrom = limitFrom;
            LimitTo = limitTo;
            Price = price;
        }
    }
}
