﻿namespace OrderManagement.Api.Controllers;

using Microsoft.AspNetCore.Mvc;
using OrderManagement.Dtos;
using MediatR;

[ApiController]
[Route("api")]
[ApiConventionType(typeof(WebApiConventions))]
public class OrdersController(ILogger<CustomersController> logger) : ControllerBase
{
  [HttpGet("customers/{customerId}/orders")]
  public Task<ActionResult<IEnumerable<OrderDto>>> GetOrdersOfCustomer(Guid customerId)
  {
    return Task.FromResult<ActionResult<IEnumerable<OrderDto>>>(NotFound());
  }

  [HttpPost("customers/{customerId}/orders")]
  public Task<ActionResult<OrderDto>> CreateOrderForCustomer(Guid customerId, OrderForCreationDto order)
  {
    return Task.FromResult<ActionResult<OrderDto>>(new StatusCodeResult(StatusCodes.Status501NotImplemented));
  }

  [HttpGet("orders/{orderId}")]
  public Task<ActionResult<OrderDto>> GetOrderById(Guid orderId)
  {
    return Task.FromResult<ActionResult<OrderDto>>(NotFound());
  }
}
