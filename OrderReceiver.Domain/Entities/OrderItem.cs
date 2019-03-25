using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderReceiver.Domain.Entities
{
    public class OrderItem : EntityBase
    {
        [ForeignKey("Order")]
        public Guid OrderId { get; set; }
        public virtual Order Order { get; set; }

        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        //public int Rentability { get; set; }

        public int GetRentability()
        {
            if (Product == null)
            {
                return 0;
            }
            if (UnitPrice > Product.UnitPrice)
            {
                return 3;
            }
            else if (UnitPrice <= Product.UnitPrice && UnitPrice >= Product.UnitPrice - (Product.UnitPrice * (10 / 100)))
            {
                return 2;
            }
            else { return 1; }
        }
    }
}
