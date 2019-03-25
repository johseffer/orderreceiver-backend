using AutoMapper;
using Moq;
using NUnit.Framework;
using OrderReceiver.Domain.Entities;
using OrderReceiver.Domain.Interfaces.Repository;
using OrderReceiver.Domain.Interfaces.Service;
using OrderReceiver.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderReceiver.Service.UnitTest.Services
{
    public class UTOrderService
    {
        private Mock<IOrderRepository> _orderRepository;
        private Mock<IOrderItemService> _orderItemService;
        private Mock<IMapper> _mapper;
        private OrderService _orderService;

        private Guid _CustomerId;
        private Guid _OrderId;
        private List<OrderItem> _OrderItems;

        private Guid _OrderItem1Id;
        private Guid _OrderItem2Id;
        private Guid _OrderItem3Id;

        private Guid _OrderItem1ProductId;
        private Guid _OrderItem2ProductId;
        private Guid _OrderItem3ProductId;

        private const string _OrderCustomerName = "Cliente 1";

        private const string _OrderItem1ProductName = "Produto 1";
        private const string _OrderItem2ProductName = "Produto 2";
        private const string _OrderItem3ProductName = "Produto 3";

        private const int _OrderItem1ProductQuantity = 5;
        private const int _OrderItem2ProductQuantity = 10;
        private const int _OrderItem3ProductQuantity = 8;

        private OrderItem _OrderItem1;
        private OrderItem _OrderItem2;
        private OrderItem _OrderItem3;

        [SetUp]
        public void Setup()
        {
            _orderRepository = new Mock<IOrderRepository>();
            _orderItemService = new Mock<IOrderItemService>();
            _mapper = new Mock<IMapper>();
            _orderService = new OrderService(_orderRepository.Object, _orderItemService.Object, _mapper.Object);

            _orderItemService.Setup(s => s.GetById(_OrderItem1Id)).Returns(_OrderItem1);
            _orderItemService.Setup(s => s.GetById(_OrderItem2Id)).Returns(_OrderItem2);
            _orderItemService.Setup(s => s.GetById(_OrderItem3Id)).Returns(_OrderItem3);

            _orderItemService.Setup(s => s.Remove(_OrderItem1Id));
            _orderItemService.Setup(s => s.Remove(_OrderItem2Id));
            _orderItemService.Setup(s => s.Remove(_OrderItem3Id));

            this.GetIds();
            this.GetOrderItems();
        }

        [Test]
        public void UTOrderService_Add()
        {
            var model = new Order() { };
            _orderRepository.Setup(s => s.Add(model));
            var ex = Assert.Throws<OrderReceiver.Domain.Error.ApplicationException>(() => _orderService.Add(model));
            Assert.IsTrue(ex != null && ex.Errors.Any(x => x.Message.Equals("Numero deve ser preenchido.")) && ex.Errors.Any(x => x.Message.Equals("Cliente deve ser preenchido.")));

            model = GetOrder();
            model.OrderItems.Add(new OrderItem());
            ex = Assert.Throws<OrderReceiver.Domain.Error.ApplicationException>(() => _orderService.Add(model));
            Assert.IsTrue(ex != null &&
                ex.Errors.Any(x => x.Message.Equals("Produto do item 4 deve ser preenchido."))
                && ex.Errors.Any(x => x.Message.Equals("Quantidade do item 4 deve ser preenchida."))
                && ex.Errors.Any(x => x.Message.Equals("Preço do item 4 deve ser preenchido.")));

            this.GetOrderItems();
            model = GetOrder();
            _orderService.Add(model);
        }

        [Test]
        public void UTOrderService_Put()
        {
            var model = new Order() { };
            _orderRepository.Setup(s => s.Update(model));
            var ex = Assert.Throws<OrderReceiver.Domain.Error.ApplicationException>(() => _orderService.Update(model));
            Assert.IsTrue(ex != null && ex.Errors.Any(x => x.Message.Equals("Numero deve ser preenchido.")) && ex.Errors.Any(x => x.Message.Equals("Cliente deve ser preenchido.")));

            model = GetOrder();
            model.OrderItems.Add(new OrderItem());
            ex = Assert.Throws<OrderReceiver.Domain.Error.ApplicationException>(() => _orderService.Add(model));
            Assert.IsTrue(ex != null &&
                ex.Errors.Any(x => x.Message.Equals("Produto do item 4 deve ser preenchido."))
                && ex.Errors.Any(x => x.Message.Equals("Quantidade do item 4 deve ser preenchida."))
                && ex.Errors.Any(x => x.Message.Equals("Preço do item 4 deve ser preenchido.")));

            this.GetOrderItems();
            model = GetOrder();
            _orderService.Update(model);
        }

        [Test]
        public void UTOrderService_GetById()
        {
            _orderRepository.Setup(s => s.GetById(_OrderId)).Returns(this.GetOrder);
            var model = _orderService.GetById(_OrderId);
            Assert.IsTrue(model != null);
        }

        private Order GetOrder()
        {
            return new Order()
            {
                Id = _OrderId,
                CreationDate = DateTime.Now,
                CustomerId = _CustomerId,
                Customer = new Customer() { Id = _CustomerId, Name = _OrderCustomerName },
                Number = "99999999",
                OrderItems = _OrderItems
            };
        }

        private void GetIds()
        {
            _CustomerId = Guid.NewGuid();
            _OrderId = Guid.NewGuid();

            _OrderItem1Id = Guid.NewGuid();
            _OrderItem2Id = Guid.NewGuid();
            _OrderItem3Id = Guid.NewGuid();

            _OrderItem1ProductId = Guid.NewGuid();
            _OrderItem2ProductId = Guid.NewGuid();
            _OrderItem3ProductId = Guid.NewGuid();
        }

        private void GetOrderItems()
        {
            _OrderItem1 = new OrderItem()
            {
                Id = _OrderItem1Id,
                OrderId = _OrderId,
                ProductId = _OrderItem1ProductId,
                Product = new Product()
                {
                    Id = _OrderItem1ProductId,
                    Multiple = 5,
                    Name = _OrderItem1ProductName,
                    UnitPrice = 10
                },
                Quantity = _OrderItem1ProductQuantity,
                UnitPrice = 10
            };

            _OrderItem2 = new OrderItem()
            {
                Id = _OrderItem2Id,
                OrderId = _OrderId,
                ProductId = _OrderItem2ProductId,
                Product = new Product()
                {
                    Id = _OrderItem2ProductId,
                    Multiple = 5,
                    Name = _OrderItem2ProductName,
                    UnitPrice = 10
                },
                Quantity = _OrderItem2ProductQuantity,
                UnitPrice = 10
            };
            _OrderItem3 = new OrderItem()
            {
                Id = _OrderItem3Id,
                OrderId = _OrderId,
                ProductId = _OrderItem3ProductId,
                Product = new Product()
                {
                    Id = _OrderItem3ProductId,
                    Multiple = 5,
                    Name = _OrderItem3ProductName,
                    UnitPrice = 10
                },
                Quantity = _OrderItem3ProductQuantity,
                UnitPrice = 10
            };

            _OrderItems = new List<OrderItem>()
            {
               _OrderItem1,
               _OrderItem2,
               _OrderItem3
            };
        }
    }
}