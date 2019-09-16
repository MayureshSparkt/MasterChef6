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
    public class AuditionDataAccess : IAuditionDataAccess
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DPEntities"].ToString();

        public List<AuditionModel> GetAudition(string filterdata, int currentpage, int pagesize)
        {
            List<AuditionModel> audition = new List<AuditionModel>();
            try
            {
                Dictionary<string, object> inputparam = new Dictionary<string, object>();
                inputparam.Add("FilterData", filterdata);
                inputparam.Add("CurrentPage", currentpage);
                inputparam.Add("PageSize", pagesize);
                audition = DataBaseHelper.ExecuteStoreProcedure<AuditionModel>(connectionString, "prcGetAudition", inputparam).ToList();
                return audition;
            }
            catch (Exception ex)
            {

                LogService.Log("Error in GetAudition of AuditionDataAccess: " + ex.Message);
                throw ex;
            }
        }

        public bool InsertUpdateAudition(AuditionModel entity)
        {
            var result = false;
            try
            {
                Dictionary<string, object> inputparam = new Dictionary<string, object>();
                inputparam.Add("Id", entity.AuditionId);
                inputparam.Add("CityID", entity.CityId);
                inputparam.Add("Venue", entity.Venue);
                inputparam.Add("Day", entity.Day);
                if (string.IsNullOrWhiteSpace(entity.PlaceId))
                {
                    inputparam.Add("PlaceId", DBNull.Value);
                }
                else
                {
                    inputparam.Add("PlaceId", entity.PlaceId);
                }


                inputparam.Add("Date", entity.Date);
                inputparam.Add("MaxDate", DateTime.UtcNow);//entity.MaxDate
                inputparam.Add("IsActive", entity.IsActive);
                inputparam.Add("CreatedBy", entity.CreatedBy);
                inputparam.Add("CreatedDate", entity.CreatedDate);

                result = DataBaseHelper.ExecuteStoreProcedure<int>(connectionString, "dbo.prcInsertUpdateAudition", inputparam).FirstOrDefault() > 0;
            }
            catch (Exception ex)
            {
                LogService.Log("Error in InsertUpdateAudition of AuditionDataAccess: " + ex.Message);
                throw ex;
            }
            return result;
        }

        public AuditionModel GetAuditionById(int auditionId)
        {
            AuditionModel result = new AuditionModel();
            try
            {
                Dictionary<string, object> inputparam = new Dictionary<string, object>();
                inputparam.Add("AuditionId", auditionId);
                result = DataBaseHelper.ExecuteStoreProcedure<AuditionModel>(connectionString, "prcGetAuditionById", inputparam).FirstOrDefault();
                return result;
            }
            catch (Exception ex)
            {
                LogService.Log("Error in GetAuditionById of AuditionDataAccess: " + ex.Message);
                throw ex;
            }

        }


        public List<AuditionModel> GetAuditionByCityId(int cityId)
        {
            List<AuditionModel> result = new List<AuditionModel>();
            try
            {
                Dictionary<string, object> inputparam = new Dictionary<string, object>();
                inputparam.Add("CityId", cityId);
                result = DataBaseHelper.ExecuteStoreProcedure<AuditionModel>(connectionString, "prcGetAuditionByCityId", inputparam);
                return result;
            }
            catch (Exception ex)
            {
                LogService.Log("Error in GetAuditionByCityId of AuditionDataAccess: " + ex.Message);
                throw ex;
            }

        }


        public bool DeleteAudition(int auditionId)
        {
            var result = false;
            try
            {
                Dictionary<string, object> inputparam = new Dictionary<string, object>();
                inputparam.Add("AuditionId", auditionId);
                DataBaseHelper.ExecuteStoreProcedure(connectionString, "dbo.prcDeleteAudition", inputparam);
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                LogService.Log("Error in DeleteAudition of AuditionDataAccess: " + ex.Message);
                throw ex;
                
            }
            return result;
        }
    }
}
