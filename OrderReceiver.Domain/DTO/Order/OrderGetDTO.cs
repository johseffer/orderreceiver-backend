using OrderReceiver.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderReceiver.Domain.DTO.Order
{
    public class OrderGetDTO : EntityBase
    {        
        public string Number { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}
