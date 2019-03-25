using OrderReceiver.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderReceiver.Domain.DTO.Order
{
    public class OrderGetDetailDTO : EntityBase
    {
        public virtual IList<OrderGetDetailItemDTO> OrderItems { get; set; }

        public string Number { get; set; }

        public virtual OrderGetDetailCustomerDTO Customer { get; set; }

        public Guid CustomerId { get; set; }

        public DateTime? CreationDate { get; set; }
    }
}
