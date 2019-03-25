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
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _OrderRepository;
        private readonly IOrderItemService _OrderItemService;

        public OrderService(IOrderRepository OrderRepository, IOrderItemService OrderItemService, IMapper mapper)
        {
            _OrderRepository = OrderRepository;
            _OrderItemService = OrderItemService;
            _mapper = mapper;
        }

        public void Add(Order obj)
        {
            var validationMessages = obj.IsValid();
            if (validationMessages.Any())
            {
                throw new OrderReceiver.Domain.Error.ApplicationException(validationMessages);
            }

            obj.CreationDate = DateTime.Now;
            obj.Customer = null;
            foreach (var item in obj.OrderItems)
            {
                item.OrderId = obj.Id;
                item.Product = null;
            }

            _OrderRepository.Add(obj);
        }

        public void Remove(Guid id)
        {
            _OrderRepository.Remove(id);
        }

        public void Update(Order obj)
        {
            var validationMessages = obj.IsValid();
            if (validationMessages.Any())
            {
                throw new OrderReceiver.Domain.Error.ApplicationException(validationMessages);
            }

            _OrderRepository.Update(obj);
            this.UpdateItems(obj);
        }

        public void UpdateItems(Order obj)
        {
            foreach (var item in obj.OrderItems)
            {
                if (_OrderItemService.GetById(item.Id) != null)
                    _OrderItemService.Remove(item.Id);
                item.Product = null;
                _OrderItemService.Add(item);
            }
        }

        public List<OrderGetDTO> GetOrderByNumberWith(string number)
        {
            return _OrderRepository.GetAll().Where(x => x.Number.Contains(number)).Select(obj => _mapper.Map<Order, OrderGetDTO>(obj)).ToList();
        }

        public OrderGetDetailDTO GetById(Guid id)
        {
            var obj = _OrderRepository.GetById(id);
            var dto = new OrderGetDetailDTO()
            {
                Id = obj.Id,
                CreationDate = obj.CreationDate,
                Number = obj.Number,
                Customer = new OrderGetDetailCustomerDTO() { Name = obj.Customer.Name, Id = obj.Customer.Id },
                CustomerId = obj.CustomerId,
                OrderItems = obj.OrderItems.Select(x => new OrderGetDetailItemDTO()
                {
                    Id = x.Id,
                    OrderId = x.OrderId,
                    Product = new OrderGetDetailProductDTO()
                    {
                        Id = x.Product.Id,
                        Name = x.Product.Name,
                        Multiple = x.Product.Multiple,
                        UnitPrice = x.Product.UnitPrice
                    },
                    ProductId = x.Product.Id,
                    Quantity = x.Quantity,
                    UnitPrice = x.UnitPrice
                }).ToList()
            };
            return dto;
        }

        public void Dispose()
        {
            _OrderRepository.Dispose();
        }
    }
}
