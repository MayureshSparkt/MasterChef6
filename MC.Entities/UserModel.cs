using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Entities
{
   public class UserModel
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int UserRoleId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public int TotalRecords { get; set; }
    }
}
