using MC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.DataAccess.Interface
{
     public interface ICityDataAccess
    {
        List<CityModel> GetCity();

        List<CityModel> GetAuditionCity();
    }
}
