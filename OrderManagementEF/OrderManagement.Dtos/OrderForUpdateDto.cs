namespace OrderManagement.Dtos;

public record OrderForUpdateDto
{
  public required DateTimeOffset OrderDate { get; set; }

  public required string Article { get; set; } = string.Empty;

  public required decimal TotalPrice { get; set; }
}
