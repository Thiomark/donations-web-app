using System.Collections.Generic;

namespace Donation.Models
{
    public class HomeInfo
    {
        public List<Disaster> disasters { get; set; }
        public List<AllocateGoods> allocatedGoodsDonations { get; set; }
        public List<AllocateMoney> allocatedMoneyDonations { get; set; }
        public string moneyDonationsMade { get; set; }
        public string moneyDonationsAllocated { get; set; }
        public int goodsReceivedCount { get; set; }
    }
}
