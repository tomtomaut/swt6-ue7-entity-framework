namespace OrderManagement.Logic.Contracts.Queries;

using MediatR;

public interface IQuery<out TResponse> : IRequest<TResponse>
{
}
