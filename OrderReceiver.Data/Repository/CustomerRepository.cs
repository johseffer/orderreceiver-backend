using OrderReceiver.Data.Context;
using OrderReceiver.Domain.Entities;
using OrderReceiver.Domain.Interfaces;
using OrderReceiver.Domain.Interfaces.Repository;

namespace OrderReceiver.Data.Repository
{
    public class CustomerRepository : ORRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ORContext context) : base(context)
        {
        }
    }
}
