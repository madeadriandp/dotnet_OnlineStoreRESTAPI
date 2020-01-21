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
    [AllowAnonymous]
    [ApiController]
    [Route("login")]
    
    public class LoginController : ControllerBase
    {
    private CoreDbContext _context;


        // private readonly ILogger<LoginController> _logger;

        public LoginController(CoreDbContext context)
        {
                _context = context;
        }     
        
       
        
        [HttpPost]
        public IActionResult Authenticate(Login login)
        {
            var _login = _context.Logins.SingleOrDefault(e => e.username==login.username && e.password==login.password);
            if(_login == null)
            {
                 return BadRequest(new { message = "Username or password is incorrect" });
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] 
                {
                    new Claim(ClaimTypes.Name, _login.username),
                    // new Claim(ClaimTypes.Anonymous, _login.password),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes("ini secret key nya coy")), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var loginNew = new {
                    id = _login.id,
                    // customer_id = _login.id,
                    username = _login.username,
                    // password =_login.password,
                    token = tokenHandler.WriteToken(token)
                }; 
            
            return Ok(loginNew);
        }
            


    }
}
