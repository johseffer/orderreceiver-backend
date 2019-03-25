using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderReceiver.Domain.Entities
{
    public class Product : EntityBase
    {
        public string Name { get; set; }
        public virtual IList<OrderItem> OrderItems { get; set; }
        public decimal UnitPrice { get; set; }
        public int Multiple { get; set; }
    }
}
