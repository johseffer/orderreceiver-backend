using OrderReceiver.Domain.Interfaces.Service;
using OrderReceiver.Domain.Interfaces.Repository;
using OrderReceiver.Domain.Entities;
using System.Linq;
using OrderReceiver.Domain.DTO.Order;
using System.Collections.Generic;
using AutoMapper;

namespace OrderReceiver.Service.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public void Dispose()
        {
            _customerRepository.Dispose();
        }

        public List<CustomerGetDTO> GetCustomerByNameWith(string name)
        {
            return _customerRepository.GetAll().Where(x => x.Name.ToUpper().Contains(name.ToUpper())).Select(x => _mapper.Map<Customer, CustomerGetDTO>(x)).ToList();
        }
    }
}
