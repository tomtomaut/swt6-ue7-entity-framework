namespace OrderManagement.Domain;

public class Address(int zipCode, string city, string? street = null)
{
	public int ZipCode { get; set; } = zipCode;
	public string City { get; set; } = city;
	public string? Street { get; set; } = street;

	public override string ToString() => $"Address {{ ZipCode: {ZipCode}, City: {City}, Street: {Street ?? ""} }}";
}
