namespace OrderManagement.Logic.Contracts.Queries;

using OrderManagement.Dtos;

public record FindCustomersQuery(Rating? Rating = null) : IQuery<IEnumerable<CustomerDto>>{}
