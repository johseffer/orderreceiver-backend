using OrderReceiver.Data.Context;
using OrderReceiver.Domain.Entities;
using OrderReceiver.Domain.Interfaces;
using OrderReceiver.Domain.Interfaces.Repository;

namespace OrderReceiver.Data.Repository
{
    public class ProductRepository : ORRepository<Product>, IProductRepository
    {
        public ProductRepository(ORContext context) : base(context)
        {
        }
    }
}
