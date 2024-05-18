using IntroEF.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroEF.Dal
{
    public class OrderManagementContext : DbContext
    {

        // TODO define DbSets

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Utils.ConfigurationUtil.GetConnectionString("OrderDbConnection"))
                .EnableSensitiveDataLogging() //loggs sensitive data
                .LogTo(Console.WriteLine, LogLevel.Information);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          // TODO define mappings
        }


    }
}
