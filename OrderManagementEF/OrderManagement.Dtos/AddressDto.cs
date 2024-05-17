namespace OrderManagement.Dtos;

public record AddressDto
{
  public required int ZipCode { get; set; }

  public required string City { get; set; } = string.Empty;

  public required string? Street { get; set; }
}
