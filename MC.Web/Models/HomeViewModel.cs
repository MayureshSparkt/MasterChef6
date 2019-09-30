using MC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MC.Web.Models
{
    public class HomeViewModel
    {
        public int CityId { get; set; }

        public List<AuditionModel> AuditionList { get; set; }
    }
}