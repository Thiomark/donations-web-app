using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

namespace Donation.Models
{
    public class GoodsDonation
    {
        public int Id { get; set; }
        [Display(Name = "Number of items")]
        public int NumberOfItems { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Description { get; set; }
        public string Donor { get; set; } = string.Empty;
        [Display(Name = "Remaining items")]
        public int RemainingItems { get; set; }
    }
}
