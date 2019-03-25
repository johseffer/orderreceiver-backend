using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderReceiver.Domain.DTO.Order;
using OrderReceiver.Domain.Entities;
using OrderReceiver.Domain.Interfaces.Service;

namespace OrderReceiver.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductController(IProductService service)
        {
            _service = service;
        }

        // GET api/Product
        [HttpGet("{name}")]
        public List<ProductGetDTO> Get(string name)
        {
            return _service.GetProductByNameWith(name).ToList();
        }     
    }
}
