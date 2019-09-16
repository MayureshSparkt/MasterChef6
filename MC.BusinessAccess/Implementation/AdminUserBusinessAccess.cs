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
    public class AdminUserBusinessAccess : IAdminUserBusinessAccess
    {
        private readonly IAdminUserDataAccess _userDataAccess;
        public AdminUserBusinessAccess(IAdminUserDataAccess userDataAccess)
        {
            _userDataAccess = userDataAccess;
        }
        public UserModel GetUserByEmail(string username)
        {
            try
            {
                return _userDataAccess.GetUserByEmail(username);
            }
            catch (Exception ex)
            {

                LogService.Log("Error in GetUserByEmail of AdminUserBusinessAccess: " + ex.Message);
                throw ex;
            }
        }
    }
}
