using OrderReceiver.Data.Context;
using OrderReceiver.Domain.Entities;
using OrderReceiver.Domain.Interfaces;
using OrderReceiver.Domain.Interfaces.Repository;

namespace OrderReceiver.Data.Repository
{
    public class OrderRepository : ORRepository<Order>, IOrderRepository
    {
        public OrderRepository(ORContext context) : base(context)
        {
        }
    }
}
