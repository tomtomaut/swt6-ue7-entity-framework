namespace OrderManagement.Dtos;

public record CustomerForUpdateDto
{
  public required string Name { get; set; } = string.Empty;

  public required Rating Rating { get; set; }
}
