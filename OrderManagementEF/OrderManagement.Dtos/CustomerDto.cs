namespace OrderManagement.Dtos;

public record CustomerDto
{
  public required Guid Id { get; set; }

  public required string Name { get; set; } = string.Empty;

  public required Rating Rating { get; set; }

  public decimal? TotalRevenue { get; set; }

  public AddressDto? Address { get; set; }
}
