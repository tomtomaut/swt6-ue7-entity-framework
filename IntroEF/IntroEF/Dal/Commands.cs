namespace IntroEF.Dal; 

using IntroEF.Domain;
using Microsoft.EntityFrameworkCore;

public static class Commands
{
  public static async Task AddCustomersAsync()
  {
    var customer1 = new Customer("Mayr Immobilien", Rating.B);
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

    var customers = await db.Customers.AsNoTracking().ToListAsync(); // AsNoTracking -> readOnly, forget Entities

    foreach (var customer in customers)
    {
      Console.WriteLine(customer);
    }
  }

  public static async Task AddOrdersAsync()
  {
    /*
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
    */
  }
}
