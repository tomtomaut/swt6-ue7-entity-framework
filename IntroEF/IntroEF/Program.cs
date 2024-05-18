using IntroEF.Dal;
using IntroEF.Utils;
using static IntroEF.Utils.PrintUtil;

PrintTitle("Introduction to EntityFramework", character: '=');

using (var db = new OrderManagementContext())
{
  // db context
  await DatabaseUtil.CreateDatabaseAsync(db);
  Console.WriteLine("DB connection available!");

  PrintTitle("Adding Customers");
  await Commands.AddCustomersAsync();

  PrintTitle("List Customers");
  await Commands.ListCustomersAsync();


}