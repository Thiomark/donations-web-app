using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Donation.Models
{
    public class AllocateMoney
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        [Display(Name = "Allocated Resources To")]
        public string AllocatedTo { get; set; }
        public string Description { get; set; }

    }
}
