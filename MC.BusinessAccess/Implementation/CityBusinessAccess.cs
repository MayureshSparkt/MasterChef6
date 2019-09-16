using MC.BusinessAccess.Interface;
using MC.DataAccess.Interface;
using MC.Entities;
using MC.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.BusinessAccess.Implementation
{
    public class CityBusinessAccess : ICityBusinessAccess
    {
        private readonly ICityDataAccess _cityDataAccess;
        public CityBusinessAccess(ICityDataAccess cityDataAccess)
        {
            _cityDataAccess = cityDataAccess;
        }

        public List<CityModel> GetCity()
        {
            try
            {
                return _cityDataAccess.GetCity();
            }
            catch (Exception ex)
            {

                LogService.Log("Error in GetCity of CityBusinessAccess : " + ex.Message);
                throw ex;
            }
        }

        public List<CityModel> GetAuditionCity()
        {
            try
            {
                return _cityDataAccess.GetAuditionCity();
            }
            catch (Exception ex)
            {
                LogService.Log("Error in GetAuditionCity of CityBusinessAccess : " + ex.Message);
                throw ex;
            }
        }
    }
}
