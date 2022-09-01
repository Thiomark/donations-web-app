using System.ComponentModel.DataAnnotations;
using System;

namespace Donations.Models
{
    public class Disaster
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
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
