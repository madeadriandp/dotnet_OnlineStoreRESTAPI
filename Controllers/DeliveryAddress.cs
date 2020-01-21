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
    [Route("deliveryaddress")]

    public class DeliveryAddressController : ControllerBase
    {
    private CoreDbContext _context;


        private readonly ILogger<DeliveryAddressController> _logger;

        public DeliveryAddressController(ILogger<DeliveryAddressController> logger, CoreDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        
        [HttpGet]
        public IActionResult GetAllDeliveryAddresses()
        {
            return Ok(_context.DeliveryAddresses.Include("Orders.OrderItems"));
        }

        [HttpGet("{id}")]
        public IActionResult GetDeliveryAddress (int id )
        {
            var deliveryaddress = _context.DeliveryAddresses.FirstOrDefault(e=>e.id==id);
            if(deliveryaddress==null)
            {
                return NotFound();
            }
            return Ok(deliveryaddress);
        }
      

        [HttpPost]
        public DeliveryAddress AddDeliveryAddress(DeliveryAddress deliveryaddress)
        {
            _context.DeliveryAddresses.Add(deliveryaddress);
            _context.SaveChanges();
            return deliveryaddress;
        } 

        [HttpPut ("{id}")]
        public DeliveryAddress EditDeliveryAddress(int id, DeliveryAddress item)
        {
           DeliveryAddress deliveryaddress = _context.DeliveryAddresses.Where(e=>e.id==id).Single<DeliveryAddress>();
           deliveryaddress.name=item.name;
           deliveryaddress.address=item.address;
          
           _context.SaveChanges();
           return deliveryaddress;
         } 

        [HttpDelete ("{id}")]
        public IEnumerable<DeliveryAddress> DeleteDeliveryAddress(int id)
        {   
            DeliveryAddress deliveryaddress = _context.DeliveryAddresses.Where(item => item.id==id).Single<DeliveryAddress>();
            _context.DeliveryAddresses.Remove(deliveryaddress);
            _context.SaveChanges();
            return _context.DeliveryAddresses;
        }

        

             


       
    }
}
