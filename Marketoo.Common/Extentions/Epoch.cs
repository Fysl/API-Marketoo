using System;

namespace Marketoo.Common.Extentions
{
    public static class Epoch
    {
        public static long ToEpoch(this DateTime value)
        {
            TimeSpan t = value - new DateTime(1970, 1, 1);
            return (long)t.TotalSeconds;
        }
        public static long ToEpochMilliSeconds(this DateTime value)
        {
            TimeSpan t = value - new DateTime(1970, 1, 1);
            return (long)t.TotalMilliseconds;
        }
        public static DateTime ToDateTime(long milliSeconds)
        {
            return DateTimeOffset.FromUnixTimeMilliseconds(milliSeconds * 1000).DateTime;
        }
        public static DateTime? ToNullableDateTime(long milliSeconds)
        {
            if (milliSeconds == 0)
                return null;
            else
                return DateTimeOffset.FromUnixTimeMilliseconds(milliSeconds * 1000).DateTime;
        }
        public static DateTime ToDate(long milliSeconds)
        {
            return ToDateTime(milliSeconds).Date;
        }
    }
}
