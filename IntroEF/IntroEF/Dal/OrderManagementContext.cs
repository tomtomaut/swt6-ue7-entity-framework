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

      public DbSet<Customer> Customers => Set<Customer>(); //explicite Verwaltung
      public DbSet<Order> Orders => Set<Order>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Utils.ConfigurationUtil.GetConnectionString("OrderDbConnection"))
                .EnableSensitiveDataLogging() //loggs sensitive data
                .LogTo(Console.WriteLine, LogLevel.Warning);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          modelBuilder.Entity<Customer>()
        //    .ToTable("GiveTheTableAName")
        //    .HasKey(c => c.Id)
            .Property(c => c.TotalRevenue)
            .HasPrecision(18,2);

          modelBuilder.Entity<Customer>()
            .OwnsOne(c => c.Address); //One to One relation, is embedded without ID

          modelBuilder.Entity<Customer>()
            .HasMany(c => c.Orders)// OneToMany
            .WithOne(o => o.Customer)
            .IsRequired();

          modelBuilder.Entity<Order>()
            .Property(o => o.TotalPrice)
            .HasPrecision(18,4);


        }


    }
}
