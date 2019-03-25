using AutoMapper;
using OrderReceiver.Domain.DTO.Order;
using OrderReceiver.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderReceiver.Server
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Order, OrderGetDTO>();
        }
    }
}

