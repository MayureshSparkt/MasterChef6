using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MC.Web.Core
{
    public class CustomPrincipalSerializeModel
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string[] roles { get; set; }
    }
}