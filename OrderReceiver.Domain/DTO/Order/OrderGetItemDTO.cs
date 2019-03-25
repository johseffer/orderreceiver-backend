using OrderReceiver.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderReceiver.Domain.DTO.Order
{
    public class OrderGetItemDTO : EntityBase
    {
        public Guid OrderId { get; set; }
        public OrderGetProductDTO Product { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
