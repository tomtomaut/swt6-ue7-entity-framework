﻿namespace OrderManagement.Logic.Contracts.Commands;

using MediatR;

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}

