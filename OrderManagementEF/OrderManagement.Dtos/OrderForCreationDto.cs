namespace OrderManagement.Dtos;

public record OrderForCreationDto
{
  public required string Article { get; set; } = string.Empty;

  public required DateTimeOffset OrderDate { get; set; }

  public required decimal TotalPrice { get; set; }
}
