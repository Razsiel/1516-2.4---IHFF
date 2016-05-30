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
        Special GetSpecial(int id);
        IEnumerable<Special> GetSpecials(int id);
    }
}
