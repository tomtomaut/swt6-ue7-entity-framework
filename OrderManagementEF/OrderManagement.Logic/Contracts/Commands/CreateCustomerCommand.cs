namespace OrderManagement.Logic.Contracts.Commands;

using OrderManagement.Dtos;

public record CreateCustomerCommand(CustomerForCreationDto Customer) : ICommand<CustomerDto>{}
