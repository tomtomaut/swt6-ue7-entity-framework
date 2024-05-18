using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IntroEF.Domain;

//[Table("TBL_Customer")] //optional Annotation
public class Customer
{
  public Customer(string name, Rating rating) : this(Guid.NewGuid(), name, rating)
  {
  }

  public Customer(Guid id, string name, Rating rating)
  {
    this.Id = id;
    this.Name = name;
    this.Rating = rating;
  }

  //[Key] //optional Annotation
  public Guid Id { get; set; }
  //[Required]
  public string Name { get; set; }
  public Rating Rating { get; set; }
  //[Column("Ref")]
  //[Column(TypeName = "decimal(10,2)")] alternativ OrderManagementContext
  public decimal? TotalRevenue { get; set; } //? nullable

  public override string ToString() => $"Customer {{ Id: {Id}, Name: {Name}, " +
                                       $"TotalRevenue: {TotalRevenue} }}";
}
