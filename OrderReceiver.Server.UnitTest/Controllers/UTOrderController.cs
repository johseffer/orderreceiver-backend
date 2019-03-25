using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using OrderReceiver.Domain.Entities;
using OrderReceiver.Domain.Interfaces.Service;
using OrderReceiver.Server.Controllers;
using System;
using System.Collections.Generic;

namespace OrderReceiver.Server.UnitTest.Controllers
{
    public class UTOrderController
    {
        private Mock<IOrderService> _OrderService;
        private Mock<IMapper> _Mapper;
        private OrderController _OrderController;

        private Guid _OrderId;
        private Guid _CustomerId;
        private const string _OrderCustomerName = "Cliente 1";
        private List<OrderItem> _OrderItems;

        [SetUp]
        public void Setup()
        {
            _OrderService = new Mock<IOrderService>();
            _Mapper = new Mock<IMapper>();
            _OrderController = new OrderController(_OrderService.Object, _Mapper.Object);

            _CustomerId = Guid.NewGuid();
            _OrderId = Guid.NewGuid();
        }

        [Test]
        public void UTOrderController_Post()
        {
            var model = new Order();
            _OrderService.Setup(s => s.Add(model));
            var actionResult = _OrderController.Post(model);
            Assert.IsAssignableFrom<BadRequestObjectResult>(actionResult);

            this._OrderItems = new List<OrderItem>() { new OrderItem() { } };
            model = this.GetOrder();
            actionResult = _OrderController.Post(model);
            Assert.IsAssignableFrom<BadRequestObjectResult>(actionResult);

            this._OrderItems = new List<OrderItem>();
            model = this.GetOrder();
            actionResult = _OrderController.Post(model);
            Assert.IsAssignableFrom<OkResult>(actionResult);
        }

        [Test]
        public void UTOrderController_Put()
        {
            var model = new Order();
            _OrderService.Setup(s => s.Update(model));
            var actionResult = _OrderController.Put(_OrderId, model);
            Assert.IsAssignableFrom<BadRequestObjectResult>(actionResult);

            this._OrderItems = new List<OrderItem>() { new OrderItem() { } };
            model = this.GetOrder();
            actionResult = _OrderController.Put(_OrderId, model);
            Assert.IsAssignableFrom<BadRequestObjectResult>(actionResult);

            this._OrderItems = new List<OrderItem>();
            model = this.GetOrder();
            actionResult = _OrderController.Put(_OrderId, model);
            Assert.IsAssignableFrom<OkResult>(actionResult);
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
    }
}