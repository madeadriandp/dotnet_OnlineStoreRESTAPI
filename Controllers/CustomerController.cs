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
    [Route("customer")]

    public class CustomerController : ControllerBase
    {
    private CoreDbContext _context;


        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ILogger<CustomerController> logger, CoreDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        
        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            return Ok(_context.Customers.Include("Orders.OrderItems").Include("Logins"));
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomer (int id )
        {
            var customer = _context.Customers.FirstOrDefault(e=>e.id==id);
            if(customer==null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
        // public Customer GetCustomer (int id)
        // {   
        //     return _context.Customers.Include("Posts.Comments").Where(item => item.id == id).Single<Customer>();   
        // }

        [HttpPost]
        public Customer AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        } 

        [HttpPut ("{id}")]
        public Customer EditCustomer(int id, Customer item)
        {
           Customer customer = _context.Customers.Where(e=>e.id==id).Single<Customer>();
        //    Customer user = _context.Customers.ElementAt<Customer>(id);
           customer.name=item.name;
           customer.address=item.address;
          
           _context.SaveChanges();
           return customer;
         } 

        [HttpDelete ("{id}")]
        public IEnumerable<Customer> DeleteCustomer(int id)
        {   
            Customer customer = _context.Customers.Where(item => item.id==id).Single<Customer>();
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return _context.Customers;
        }

        

             


       
    }
}
