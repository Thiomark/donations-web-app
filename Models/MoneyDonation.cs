using System;

namespace Donation.Models
{
    public class MoneyDonation
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public string Donor { get; set; }
        public bool Used { get; set; } = false;
        public string Description { get; set; }
    }
}
