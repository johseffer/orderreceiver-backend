using OrderReceiver.Domain.Interfaces.Service;
using OrderReceiver.Domain.Interfaces.Repository;
using OrderReceiver.Domain.Entities;
using System.Linq;
using System;
using OrderReceiver.Domain.DTO.Order;
using System.Collections.Generic;
using AutoMapper;

namespace OrderReceiver.Service.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IMapper _mapper;
        private readonly IOrderItemRepository _OrderItemRepository;

        public OrderItemService(IOrderItemRepository OrderItemRepository, IMapper mapper)
        {
            _OrderItemRepository = OrderItemRepository;
            _mapper = mapper;
        }

        public OrderItem GetById(Guid Id)
        {
            return _OrderItemRepository.GetById(Id);
        }

        public void Add(OrderItem obj)
        {
            _OrderItemRepository.Add(obj);
        }

        public void Remove(Guid id)
        {
            _OrderItemRepository.Remove(id);
        }

        public void Update(OrderItem obj)
        {
            _OrderItemRepository.Update(obj);
        }

        public void Dispose()
        {
            _OrderItemRepository.Dispose();
        }
    }
}
