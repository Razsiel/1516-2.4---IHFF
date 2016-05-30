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
            List<Special> uniqueSpecials = context.Specials.ToList().GroupBy(m => m.Name).Select(grp => grp.First()).ToList();
            
            return uniqueSpecials;
        }

        public Special GetSpecial(int id)
        {
            return context.Specials.FirstOrDefault(a => a.EventId == id);
        }

        public IEnumerable<Special> GetSpecials(int dayOfWeek)
        {
            if (dayOfWeek < 0)
            {
                return context.Specials.ToList().GroupBy(m => m.Name).Select(grp => grp.First()).ToList(); ;
            }

            IEnumerable<Special> specials = context.Specials.ToList().Where(a => a.Date.DayOfWeek == (DayOfWeek)dayOfWeek);

            return specials;
        }
    }
}