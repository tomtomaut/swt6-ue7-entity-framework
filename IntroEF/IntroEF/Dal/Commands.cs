using Microsoft.IdentityModel.Tokens;

namespace IntroEF.Dal; 

using IntroEF.Domain;
using Microsoft.EntityFrameworkCore;

public static class Commands
{
  public static async Task AddCustomersAsync()
  {
    var customer1 = new Customer("Mayr Immobilien", Rating.B);
    customer1.Address = new(4020, "Linz", "Hauptstraße 1");

    var customer2 = new Customer("Software Solutions", Rating.A);

    //await Task.CompletedTask;

    using var db = new OrderManagementContext();

    await db.Customers.AddRangeAsync(customer1, customer2); 
    await db.SaveChangesAsync(); //persist

  }

  public static async Task ListCustomersAsync()
  {
    //await Task.CompletedTask;
    using var db = new OrderManagementContext();

    var customers = await db.Customers
      .AsNoTracking() // AsNoTracking -> readOnly, forget Entities
      .Include(c => c.Address) //not necessary -> embedded
      .Include(c => c.Orders) // Fetching orders
      .ToListAsync();

    foreach (var customer in customers)
    {
      Console.WriteLine(customer);
      if (customer.Address is not null)
      {
        Console.WriteLine($"    {customer.Address}");
      }

      Console.WriteLine("Orders");
      if (!customer.Orders.IsNullOrEmpty())
      {
        foreach (var order in customer.Orders)
        {
          Console.WriteLine($"    {order}");
        }

      }
    }
  }

  public static async Task AddOrdersAsync()
  {
    using var db = new OrderManagementContext();

    var customer = await db.Customers.OrderBy(c => c.Id).FirstOrDefaultAsync();
    if (customer is null)
    {
        return;
    }

    var order1 = new Order("Surface Book 3", new DateTime(2022, 1, 1), 2850m);
    order1.AssignCustomer(customer);

    var order2 = new Order("Dell Monitor", new DateTime(2022, 2, 2), 250m);
    order2.AssignCustomer(customer);

    await db.Orders.AddRangeAsync(order1, order2);
    await db.SaveChangesAsync();
    
  }
}
