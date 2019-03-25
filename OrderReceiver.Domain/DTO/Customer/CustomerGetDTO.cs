using OrderReceiver.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderReceiver.Domain.DTO.Order
{
    public class CustomerGetDTO : EntityBase
    {
        public string Name { get; set; }        
    }
}
