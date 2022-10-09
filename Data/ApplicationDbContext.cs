using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Donation.Models;

namespace Donation.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Donation.Models.Category> Category { get; set; }
        public DbSet<Donation.Models.Disaster> Disaster { get; set; }
        public DbSet<Donation.Models.GoodsDonation> GoodsDonation { get; set; }
        public DbSet<Donation.Models.MoneyDonation> MoneyDonation { get; set; }
        public DbSet<Donation.Models.AllocateMoney> AllocateMoney { get; set; }
        public DbSet<Donation.Models.AllocateGoods> AllocateGoods { get; set; }
    }
}
