using MC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.BusinessAccess.Interface
{
    public interface IAuditionBusinessAccess
    {
        List<AuditionModel> GetAudition(string filterdata, int currentpage, int pagesize);

        bool InsertUpdateAudition(AuditionModel entity);

        AuditionModel GetAuditionById(int auditionId);

        List<AuditionModel> GetAuditionByCityId(int cityId);

        bool DeleteAudition(int auditionId);
    }
}
