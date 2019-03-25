using OrderReceiver.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderReceiver.Domain.Interfaces.Repository
{
    public interface IOrderRepository : IORRepository<Order>
    {
    }
}
