using IHFF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IHFF.Models;

namespace IHFF.Repositories
{
    public class SpecialsRepository : ISpecialsRepository
    {
        private IHFFContext context = IHFFContext.Instance;

        // Get unique specials titles -> new list
        public IEnumerable<Special> GetAllSpecials()
        {
            //List<Special> uniqueSpecials = context.Specials.Where(s => s.Discriminator == "S").ToList().GroupBy(m => m.Name).Select(grp => grp.First()).ToList();

            return context.Specials;
        }

        public Event GetSpecialEvent(int specialId)
        {
            return context.Events.FirstOrDefault(x => x.ItemId == specialId && x.Discriminator == ItemType.Special.ToString());
        }

        public IEnumerable<Special> GetSpecials(int dayOfWeek)
        {
            if (dayOfWeek <= 0)
            {
                return GetAllSpecials();
            }
            return context.Specials.AsEnumerable().Where(x => x.Airings.Any(a => a.Date.DayOfWeek == (DayOfWeek)dayOfWeek && a.Discriminator == ItemType.Special.ToString()));
        }
    }
}