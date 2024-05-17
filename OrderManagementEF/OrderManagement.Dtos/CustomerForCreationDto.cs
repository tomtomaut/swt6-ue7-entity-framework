namespace OrderManagement.Dtos;

public record CustomerForCreationDto
{
  public required string Name { get; set; } = String.Empty;

  public required Rating Rating { get; set; }

  public AddressDto? Address { get; set; }
}
