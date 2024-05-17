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
        var customerQuery = db.Customers
                              .AsNoTracking()
                              .Include(c => c.Address);

        if (query.Rating == null)
        {
           return await customerQuery
                .ProjectTo<CustomerDto>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken: cancellationToken);
        }
        else
        {
           var domainRating = mapper.Map<Domain.Rating>(query.Rating);

           //TODO implement rating query
          
           return null;
        }
  }
}
