using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Entities
{
    public class AuditionModel
    {
        public int AuditionId { get; set; }
        public int CityId { get; set; }
        public string City { get; set; }
        public string PlaceId { get; set; }
        public string Venue { get; set; }
        public string Day { get; set; }
        public string Date { get; set; }
        public int TotalRecords { get; set; }
        public DateTime MaxDate { get; set; }
        public bool IsActive { get; set; }
        public decimal Latitudes { get; set; }
        public decimal Longitudes { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }



    }
}
