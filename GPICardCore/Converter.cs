using Microsoft.VisualBasic;

namespace GPICardCore
{
    public static class Converter
    {
        public static Double ToDouble(this object value)
        {
            if (value == DBNull.Value || (Information.IsNumeric(value) == false))
            {
                return 0;
            }
            else
            {
                return Math.Round(Convert.ToDouble(value), 3);

            } //          
        }
        public static Int32 ToInt(this object value)
        {
            if (value == DBNull.Value || (Information.IsNumeric(value) == false))
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(value);
            }
        }

     

        public static Int64 ToInt64(this object value)
        {
            if (value == DBNull.Value || (Information.IsNumeric(value) == false))
            {
                return 0;
            }
            else
            {
                return Convert.ToInt64(value);
            }
        }
        public static Decimal ToDecimal(this object value)
        {
            if (value == DBNull.Value || (Information.IsNumeric(value) == false))
            {
                return 0;
            }
            else
            {
                return Convert.ToDecimal(value);
            }
        }
        public static DateTime? ToDateTime(this object value)
        {
            if (value == DBNull.Value || (Information.IsDate(value) == false))
            {
                return null;
            }
            else
            {
                return Convert.ToDateTime(value);
            }
        }

    }
}
