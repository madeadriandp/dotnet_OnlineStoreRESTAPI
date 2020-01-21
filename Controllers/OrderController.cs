using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using restful_api.Database;
using Microsoft.EntityFrameworkCore;
using restful_api.Models;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace api_test.Controllers
{  
    [Authorize]
    [ApiController]
    [Route("order")]

    public class OrderController : ControllerBase
    {
    private CoreDbContext _context;


        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger, CoreDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        
        [HttpGet]
        public IActionResult GetAllOrders()
        {
            return Ok(_context.Orders.Include("OrderItems"));
        }

        [HttpGet("{id}")]
        public IActionResult GetOrder (int id )
        {
            var order = _context.Orders.FirstOrDefault(e=>e.id==id);
            if(order==null)
            {
                return NotFound();
            }
            return Ok(order);
        }
      

        [HttpPost]
        public Order AddOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return order;
        } 

        [HttpPut ("{id}")]
        public Order EditOrder(int id, Order item)
        {
           Order order = _context.Orders.Where(e=>e.id==id).Single<Order>();
           order.customer_id=item.customer_id;
           order.delivery_id=item.delivery_id;
          
           _context.SaveChanges();
           return order;
         } 

        [HttpDelete ("{id}")]
        public IEnumerable<Order> DeleteOrder(int id)
        {   
            Order order = _context.Orders.Where(item => item.id==id).Single<Order>();
            _context.Orders.Remove(order);
            _context.SaveChanges();
            return _context.Orders;
        }

        

             


       
    }
}
