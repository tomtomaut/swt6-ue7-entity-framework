namespace OrderManagement.Logic.Queries;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Dal;
using OrderManagement.Dtos;
using OrderManagement.Logic.Contracts.Queries;

internal class FindCustomersHandler(OrderManagementContext db, IMapper mapper) : 
  IRequestHandler<FindCustomersQuery, IEnumerable<CustomerDto>>
{
  public async Task<IEnumerable<CustomerDto>> Handle(FindCustomersQuery query, CancellationToken cancellationToken)
  {

        //TODO implement handler logic for FindCustomersQuery
        return null;
  }
}
