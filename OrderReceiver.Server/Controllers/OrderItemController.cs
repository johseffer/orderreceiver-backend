using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderReceiver.Domain.DTO.Order;
using OrderReceiver.Domain.Entities;
using OrderReceiver.Domain.Interfaces.Service;

namespace OrderReceiver.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IMapper _mapper;
        public OrderItemController(IMapper mapper)
        {
            _mapper = mapper;
        }

        // PUT api/Order/5
        [HttpPost()]
        public ActionResult<int> GetRentability([FromBody] OrderItem model)
        {
            return Ok(model.GetRentability());
        }
    }
}
