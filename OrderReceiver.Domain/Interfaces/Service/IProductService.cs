using OrderReceiver.Definitions.IoC;
using OrderReceiver.Domain.DTO.Order;
using OrderReceiver.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderReceiver.Domain.Interfaces.Service
{
    public interface IProductService : IAutoInject, IDisposable
    {
        List<ProductGetDTO> GetProductByNameWith(string name);
    }
}
