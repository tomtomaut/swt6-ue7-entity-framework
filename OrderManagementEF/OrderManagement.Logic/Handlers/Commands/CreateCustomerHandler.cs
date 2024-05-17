namespace OrderManagement.Logic.Handlers.Commands;

using AutoMapper;
using MediatR;
using OrderManagement.Dal;
using OrderManagement.Dtos;
using OrderManagement.Logic.Contracts.Commands;
using OrderManagement.Logic.Mappings;

internal class CreateCustomerHandler(OrderManagementContext db, IMapper mapper) : IRequestHandler<CreateCustomerCommand, CustomerDto>
{
	public async Task<CustomerDto> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
    {
        //TODO implement handler logic for CreateCustomerCommand
        return null;
	}
}
