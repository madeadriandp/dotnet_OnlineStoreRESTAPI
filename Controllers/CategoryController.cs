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
    [Route("category")]

    public class CategoryController : ControllerBase
    {
    private CoreDbContext _context;


        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ILogger<CategoryController> logger, CoreDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        
        [HttpGet]
        public IActionResult GetAllCategories()
        {
            return Ok(_context.Categories.Include("Products.OrderItems"));
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory (int id )
        {
            var category = _context.Categories.FirstOrDefault(e=>e.id==id);
            if(category==null)
            {
                return NotFound();
            }
            return Ok(category);
        }
      

        [HttpPost]
        public Category AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category;
        } 

        [HttpPut ("{id}")]
        public Category EditCategory(int id, Category item)
        {
           Category category = _context.Categories.Where(e=>e.id==id).Single<Category>();
           category.name=item.name;
           category.description=item.description;
          
           _context.SaveChanges();
           return category;
         } 

        [HttpDelete ("{id}")]
        public IEnumerable<Category> DeleteCategory(int id)
        {   
            Category category = _context.Categories.Where(item => item.id==id).Single<Category>();
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return _context.Categories;
        }

        

             


       
    }
}
