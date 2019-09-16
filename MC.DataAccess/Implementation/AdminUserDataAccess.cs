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
    public class AdminUserDataAccess : IAdminUserDataAccess
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DPEntities"].ToString();

        public UserModel GetUserByEmail(string username)
        {
            try
            {
                UserModel user = new UserModel();
                Dictionary<string, object> inputparam = new Dictionary<string, object>();
                inputparam.Add("UserName", username);
                user = DataBaseHelper.ExecuteStoreProcedure<UserModel>(connectionString, "dbo.prcGetAdminDetailsByUserName", inputparam).FirstOrDefault();
                return user;
            }
            catch (Exception ex)
            {
                LogService.Log("Error in GetUserByEmail of AdminUserDataAccess: " + ex.Message);
                throw ex;
            }
        }
    }
}
