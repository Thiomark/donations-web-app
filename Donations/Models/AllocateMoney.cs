using System;

namespace Donations.Models
{
    public class AllocateMoney
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public double RemainingAmount { get; set; }
        public string AllocatedTo { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Description { get; set; }

    }
}
