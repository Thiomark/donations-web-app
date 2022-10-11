using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Donations.Models
{
    public class GoodsDonation
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
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
