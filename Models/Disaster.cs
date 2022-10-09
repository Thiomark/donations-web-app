using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

namespace Donation.Models
{
    public class Disaster
    {
        public int Id { get; set; }
        [Display(Name = "Start date")]
        public DateTime StartDate { get; set; }
        [Display(Name = "End date")]
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        [Display(Name = "Required type of aid")]
        public string RequiredTypeOfAid { get; set; }
    }
}
