using MC.DataAccess.Common;
using MC.DataAccess.Interface;
using MC.Entities;
using MC.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.DataAccess.Implementation
{
    public class CityDataAccess : ICityDataAccess
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DPEntities"].ToString();


        public List<CityModel> GetCity()
        {
            List<CityModel> city = new List<CityModel>();
            try
            {

                city = DataBaseHelper.ExecuteStoreProcedure<CityModel>(connectionString, "prcGetActiveCity", null).ToList();
                return city;
            }
            catch (Exception ex)
            {

                LogService.Log("Error in GetCity of CityDataAccess: " + ex.Message);
                throw ex;
            }
        }

        public List<CityModel> GetAuditionCity()
        {
            List<CityModel> city = new List<CityModel>();
            try
            {

                city = DataBaseHelper.ExecuteStoreProcedure<CityModel>(connectionString, "prcGetAuditionCity", null).ToList();
                return city;
            }
            catch (Exception ex)
            {
                LogService.Log("Error in GetAuditionCity of CityDataAccess: " + ex.Message);
                throw ex;
            }
        }
    }
}
