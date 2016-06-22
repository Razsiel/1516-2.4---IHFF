using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IHFF.Models;

namespace IHFF
{
    public class MultiplePeopleDiscount : DiscountRule
    {
        public MultiplePeopleDiscount(WishlistItem item)
        {
            this.Description = string.Format("Groepskorting ({0})", item.GetName());
            this.Percentage = 0.02m * item.Amount;
            this.DayOfWeek = item.Date.DayOfWeek;
            this.DiscountEvent = item;
        }
    }
}