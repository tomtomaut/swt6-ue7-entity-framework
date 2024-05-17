namespace OrderManagement.Dtos;

public record OrderDto
{
  public required Guid Id { get; set; }

  public required DateTimeOffset OrderDate { get; set; }

  public required string Article { get; set; } = string.Empty;

  public required decimal TotalPrice { get; set; }

  public required Guid CustomerId { get; set; }
}
