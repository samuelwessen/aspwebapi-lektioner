using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SharedRepository;
using SharedRepository.Models;
using WebApi.Data;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly SqlDbContext _context;
        private IConfiguration Configuration { get; }

        public UsersController(SqlDbContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }


        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody]SignUpSignIn user)
        {
            try
            {
                var _user = new User { Email = user.Email };
                _user.GeneratePassword(user.Password);

                _context.Users.Add(_user);
                await _context.SaveChangesAsync();

                return new OkResult();
            }
            catch { }

            return new BadRequestResult();
        }


        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromBody] SignUpSignIn user)
        {
            try
            {
                var _user = await _context.Users.FirstOrDefaultAsync(_user => _user.Email == user.Email);

                if (_user != null)
                {
                    if (_user.ValidatePassword(user.Password))
                    {
                        var tokenHandler = new JwtSecurityTokenHandler();

                        var tokenDescriptor = new SecurityTokenDescriptor
                        {
                            Subject = new ClaimsIdentity(new Claim[] { new Claim("UserId", _user.Id.ToString()) }),
                            Expires = DateTime.Now.AddHours(1),
                            SigningCredentials = new SigningCredentials(
                                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection("SecretKey").Value)), SecurityAlgorithms.HmacSha512Signature)
                        };

                        var _accessToken = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));

                        return new OkObjectResult(new { AccessToken = _accessToken });
                    }                    
                }                
            }
            catch { }

            return new BadRequestResult();
        }

        
    }
}
