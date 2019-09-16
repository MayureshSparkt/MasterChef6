using MC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.BusinessAccess.Interface
{
    public interface ICityBusinessAccess
    {
        List<CityModel> GetCity();

        List<CityModel> GetAuditionCity();
    }
}
