using Credit_Control.Server.Models;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Credit_Control.Server.Data
{
    public class CreditDbContext: DbContext, IDataProtectionKeyContext
    {
        public CreditDbContext(DbContextOptions options) : base(options)
        { 

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VatScheme>().HasData(
                new VatScheme { Id = "NORMAL", DisplayName = "Normal" },
                new VatScheme { Id = "EXEMPT", DisplayName = "Exempt" },
                new VatScheme { Id = "REDUCED", DisplayName = "Reduced" },
                new VatScheme { Id = "SPECIAL", DisplayName = "Special" }
            );
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<decimal>().HavePrecision(18, 2);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<VatScheme> VatSchemes { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<DataProtectionKey> DataProtectionKeys { get; set; } = null!;
    }
}
