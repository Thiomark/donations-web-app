using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Donations.Models;

namespace Donations.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Donations.Models.Category> Category { get; set; }
        public DbSet<Donations.Models.Disaster> Disaster { get; set; }
        public DbSet<Donations.Models.GoodsDonation> GoodsDonation { get; set; }
        public DbSet<Donations.Models.MoneyDonation> MoneyDonation { get; set; }
        public DbSet<Donations.Models.AllocateMoney> AllocateMoney { get; set; }
    }
}
