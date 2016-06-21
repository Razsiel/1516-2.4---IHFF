using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF
{
    public class MultipleActivitiesDayDiscount : DiscountRule
    {
        public MultipleActivitiesDayDiscount(DayOfWeek dayOfWeek)
        {
            this.Description = string.Format("Meerdere activiteitenkorting ({0})", Globals.CurrentCulture.DateTimeFormat.GetDayName(dayOfWeek));
            this.Percentage = 0.02m;
            this.DayOfWeek = dayOfWeek;
        }
    }
}