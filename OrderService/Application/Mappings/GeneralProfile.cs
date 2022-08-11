﻿using AutoMapper;
using OrderService.Domain.Entities;
using Common.Entities;
using OrderService.Application.Features.SharedViewModels;
using Common.ApplicationEvents;


using OrderService.Application.Features.Orders.Queries.GetAllOrders;

namespace OrderService.Application.Mappings
{
  public class GeneralProfile: Profile
  {
    public GeneralProfile()
    {
      CreateMap<Order, CreateOrderEvent>().ReverseMap();
      CreateMap<Order, OrderViewModel>().ReverseMap();
      CreateMap<OrderProduct, OrderProductViewModel>().ReverseMap();
      CreateMap<GetAllOrdersQuery, GetAllOrdersParameter>();
    }
  }
}
