namespace MeterOff.API.ErrorHandeling
{
    public class BusinessException : Exception
    {
        public string ErrorCode { get; }
        public BusinessException(string message, string errorCode)
            : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}

