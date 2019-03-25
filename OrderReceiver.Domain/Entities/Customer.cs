using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OrderReceiver.Domain.Entities
{
    public class Customer: EntityBase
    {
       public string Name { get; set; }
    }
}
