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
    [Route("product")]

    public class ProductController : ControllerBase
    {
    private CoreDbContext _context;


        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger, CoreDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            return Ok(_context.Products.Include("OrderItems"));
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct (int id )
        {
            var product = _context.Products.FirstOrDefault(e=>e.id==id);
            if(product==null)
            {
                return NotFound();
            }
            return Ok(product);
        }
      

        [HttpPost]
        public Product AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        } 

        [HttpPut ("{id}")]
        public Product EditProduct(int id, Product item)
        {
           Product product = _context.Products.Where(e=>e.id==id).Single<Product>();
           product.cat_id=item.cat_id;
           product.name=item.name;
           product.price=item.price;
          
           _context.SaveChanges();
           return product;
         } 

        [HttpDelete ("{id}")]
        public IEnumerable<Product> DeleteProduct(int id)
        {   
            Product product = _context.Products.Where(item => item.id==id).Single<Product>();
            _context.Products.Remove(product);
            _context.SaveChanges();
            return _context.Products;
        }

        

             


       
    }
}
