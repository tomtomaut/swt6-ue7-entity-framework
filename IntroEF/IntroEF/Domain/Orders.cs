using System.ComponentModel.DataAnnotations;

namespace IntroEF.Domain;

public class Order
{
  public Order(string article, DateTimeOffset orderDate, decimal totalPrice) :
    this(Guid.NewGuid(), article, orderDate, totalPrice)
  {
  }

  public Order(Guid id, string article, DateTimeOffset orderDate, decimal totalPrice)
  {
    this.Id = id;
    this.OrderDate = orderDate;
    this.Article = article;
    this.TotalPrice = totalPrice;
  }

  public Guid Id { get; set; }

  public string Article { get; set; }

  public DateTimeOffset OrderDate { get; set; }

  public decimal TotalPrice { get; set; }

  [Required] // in DB
  public Customer? Customer { get; set; }

  public void AssignCustomer(Customer customer)
  {
    this.Customer = customer;
    customer.Orders.Add(this);
  }

  public override string ToString() => $"Order {{ Id: {Id}, Article: {Article}, OrderDate: {OrderDate:d}, TotalPrice: {TotalPrice:F2} }}";
}
