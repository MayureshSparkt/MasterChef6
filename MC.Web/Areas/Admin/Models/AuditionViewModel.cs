using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MC.Web.Areas.Admin.Models
{
    public class AuditionViewModel
    {
        public int AuditionId { get; set; }
        [Required]
        public int CityId { get; set; }
        public string City { get; set; }
        [Required]
        public string Venue { get; set; }
        //[Required]
        public string PlaceId { get; set; }
        [Required]
        public string Day { get; set; }
        [AllowHtml]
        public string Date { get; set; }
        //[Required]
        public DateTime MaxDate { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public decimal Latitudes { get; set; }
        public decimal Longitudes { get; set; }

        public int TotalRecords { get; set; }
    }
}