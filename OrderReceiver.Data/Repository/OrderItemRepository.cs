using OrderReceiver.Data.Context;
using OrderReceiver.Domain.Entities;
using OrderReceiver.Domain.Interfaces;
using OrderReceiver.Domain.Interfaces.Repository;

namespace OrderReceiver.Data.Repository
{
    public class OrderItemRepository : ORRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(ORContext context) : base(context)
        {
        }
    }
}
