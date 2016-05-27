using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Helpers
{
    public static class DateTimeHelper
    {
        // A method to round up or down the minutes
        public static DateTime Round(DateTime dt)
        {
            if ((dt.Minute % 10) >= 5)
            {
                return dt.AddMinutes((60 - dt.Minute) % 10);
            }
            else
            {
                return dt.AddMinutes(-dt.Minute % 10);
            }
        }
    }
}