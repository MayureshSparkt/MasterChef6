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
    public class AuditionBusinessAccess : IAuditionBusinessAccess
    {
        private readonly IAuditionDataAccess _AuditionDataAccess;
        public AuditionBusinessAccess(IAuditionDataAccess AuditionDataAccess)
        {
            _AuditionDataAccess = AuditionDataAccess;
        }

        public bool DeleteAudition(int auditionId)
        {
            try
            {
                return _AuditionDataAccess.DeleteAudition(auditionId);
            }
            catch (Exception ex)
            {

                LogService.Log("Error in DeleteAudition of AuditionBusinessAccess: " + ex.Message);
                throw ex;
            }
        }

        public List<AuditionModel> GetAudition(string filterdata, int currentpage, int pagesize)
        {
            try
            {
                return _AuditionDataAccess.GetAudition(filterdata, currentpage, pagesize);
            }
            catch (Exception ex)
            {
                LogService.Log("Error in GetAudition of AuditionBusinessAccess: " + ex.Message);
                throw ex;
            }
        }

        public List<AuditionModel> GetAuditionByCityId(int cityId)
        {
            try
            {
                return _AuditionDataAccess.GetAuditionByCityId(cityId);
            }
            catch (Exception ex)
            {

                LogService.Log("Error in GetAuditionByCityId of AuditionBusinessAccess: " + ex.Message);
                throw ex;
            }
        }

        public AuditionModel GetAuditionById(int auditionId)
        {
            try
            {
                return _AuditionDataAccess.GetAuditionById(auditionId);
            }
            catch (Exception ex)
            {

                LogService.Log("Error in GetAuditionById of AuditionBusinessAccess: " + ex.Message);
                throw ex;
            }

        }



        public bool InsertUpdateAudition(AuditionModel entity)
        {
            try
            {
                return _AuditionDataAccess.InsertUpdateAudition(entity);
            }
            catch (Exception ex)
            {

                LogService.Log("Error in GetAuditionById of AuditionBusinessAccess: " + ex.Message);
                throw ex;
            }

            
        }
    }
}
