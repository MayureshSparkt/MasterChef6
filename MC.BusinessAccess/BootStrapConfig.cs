using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MC.BusinessAccess.Interface;
using MC.DataAccess.Interface;

namespace MC.BusinessAccess
{
    public class BootStrapConfig
    {
        public static void Build(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IAdminUserDataAccess).Assembly).Where(t => t.Name.EndsWith("DataAccess")).AsImplementedInterfaces().InstancePerRequest();
        }
    }
}
