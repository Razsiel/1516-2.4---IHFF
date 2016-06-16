using IHFF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHFF.Interfaces
{
    interface ISpecialsRepository
    {
        IEnumerable<Special> GetAllSpecials();
        IEnumerable<Special> GetSpecials(int id);
        Event GetSpecialEvent(int specialId);
    }
}
