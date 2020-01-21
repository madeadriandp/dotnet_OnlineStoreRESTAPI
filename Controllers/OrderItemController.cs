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
    [Route("orderItem")]

    public class OrderItemController : ControllerBase
    {
    private CoreDbContext _context;


        private readonly ILogger<OrderItemController> _logger;

        public OrderItemController(ILogger<OrderItemController> logger, CoreDbContext context)
        {
            _logger = logger;
            _context = context;
        }


        
        [HttpGet]
        public IActionResult GetAllOrderItems()
        {
            return Ok(_context.OrderItems);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderItem (int id )
        {
            var orderItemItem = _context.OrderItems.FirstOrDefault(e=>e.id==id);
            if(orderItemItem==null)
            {
                return NotFound();
            }
            return Ok(orderItemItem);
        }
      

        [HttpPost]
        public OrderItem AddOrderItem(OrderItem orderItemItem)
        {
            _context.OrderItems.Add(orderItemItem);
            _context.SaveChanges();
            return orderItemItem;
        } 

        [HttpPut ("{id}")]
        public OrderItem EditOrderItem(int id, OrderItem item)
        {
           OrderItem orderItem = _context.OrderItems.Where(e=>e.id==id).Single<OrderItem>();
           orderItem.order_id=item.order_id;
           orderItem.product_id=item.product_id;
           orderItem.quantity=item.quantity;
          
           _context.SaveChanges();
           return orderItem;
         } 

        [HttpDelete ("{id}")]
        public IEnumerable<OrderItem> DeleteOrderItem(int id)
        {   
            OrderItem orderItem = _context.OrderItems.Where(item => item.id==id).Single<OrderItem>();
            _context.OrderItems.Remove(orderItem);
            _context.SaveChanges();
            return _context.OrderItems;
        }

        

             


       
    }
}
