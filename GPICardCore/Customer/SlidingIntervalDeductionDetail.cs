namespace GPICardCore.Customer
{
    public class SlidingIntervalDeductionDetail
    {
        public int IntervaNumber { get; set; }
        public int LimitFrom { get; set; }
        public int LimitTo { get; set; }
        public decimal Price { get; set; }

        public SlidingIntervalDeductionDetail(int number, int limitFrom, int limitTo, decimal price)
        {
            IntervaNumber = number;
            LimitFrom = limitFrom;
            LimitTo = limitTo;
            Price = price;
        }
    }
}
