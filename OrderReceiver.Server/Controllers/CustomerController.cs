using Microsoft.AspNetCore.Mvc;
using OrderReceiver.Domain.DTO.Order;
using OrderReceiver.Domain.Interfaces.Service;
using System.Collections.Generic;
using System.Linq;

namespace OrderReceiver.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;
        public CustomerController(ICustomerService service)
        {
            _service = service;
        }
        
        // GET api/Customer
        [HttpGet("{name}")]
        public List<CustomerGetDTO> Get(string name)
        {
            return _service.GetCustomerByNameWith(name).ToList();
        }
    }
}
