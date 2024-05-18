using IntroEF.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Internal;

namespace IntroEF.Dal
{
    public class OrderManagementContext : DbContext
    {

      public DbSet<Customer> Customers => Set<Customer>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Utils.ConfigurationUtil.GetConnectionString("OrderDbConnection"))
                .EnableSensitiveDataLogging() //loggs sensitive data
                .LogTo(Console.WriteLine, LogLevel.Information);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          modelBuilder.Entity<Customer>()
      //      .ToTable("GiveTheTableAName")
       //     .HasKey(c => c.Id)
            .Property(c => c.TotalRevenue)
            .HasPrecision(18,2);
        }


    }
}
