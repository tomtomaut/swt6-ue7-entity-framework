namespace OrderManagement.Dal;

using Microsoft.EntityFrameworkCore;
using OrderManagement.Domain;

public class OrderManagementContext(DbContextOptions options) : DbContext(options)
{
 
  // TODO 

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {

    // TODO   

  }
}
