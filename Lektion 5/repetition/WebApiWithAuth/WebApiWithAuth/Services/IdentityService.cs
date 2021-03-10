﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApiWithAuth.Data;
using WebApiWithAuth.Models;

namespace WebApiWithAuth.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly SqlDbContext _context;
        private IConfiguration _configuration { get; }


        public IdentityService(SqlDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<bool> CreateUserAsync(SignUp model)
        {
            if (!_context.Users.Any(user => user.Email == model.Email))
            {
                try
                {
                    var user = new User()
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email
                    };
                    user.CreatePasswordWithHash(model.Password);
                    _context.Users.Add(user);
                    await _context.SaveChangesAsync();

                    return true;
                }
                catch
                {

                }
            }

            return false;
        }

        public async Task<SignInResponse> SignInAsync(string email, string password)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(user => user.Email == email);

                if (user != null)
                {
                    try
                    {
                        if (user.ValidatePasswordHash(password))
                        {
                            var tokenHandler = new JwtSecurityTokenHandler();
                            var _secretKey = Encoding.UTF8.GetBytes(_configuration.GetSection("SecretKey").Value);

                            var tokenDescriptor = new SecurityTokenDescriptor
                            {
                                Subject = new ClaimsIdentity(new Claim[] { new Claim("UserId", user.Id.ToString()) }),
                                Expires = DateTime.Now.AddSeconds(30),
                                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_secretKey), SecurityAlgorithms.HmacSha512Signature)
                            };

                            var _accessToken = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));

                            _context.SessionTokens.Add(new SessionToken { UserId = user.Id, AccessToken = _accessToken });
                            await _context.SaveChangesAsync();

                            return new SignInResponse 
                            {
                                Succeded = true,
                                Result = new SignInResponseResult
                                {
                                    Id = user.Id,
                                    Email = user.Email,
                                    AccessToken = _accessToken
                                }                                
                            };
                        }                        
                    }
                    catch { }
                }
            }
            catch { }         

            return new SignInResponse { Succeded = false };            
            
        }

        public async Task<IEnumerable<UserResponse>> GetUsersAsync()
        {
            var users = new List<UserResponse>();

            foreach (var user in await _context.Users.ToListAsync())
            {
                users.Add(new UserResponse { FirstName = user.FirstName, LastName = user.LastName, Email = user.Email });
            }

            return users;
        }

        public bool ValidateAccessRights(RequestUser requestUser)
        {
            if (_context.SessionTokens.Any(x => x.UserId == requestUser.UserId && x.AccessToken == requestUser.AccessToken))
                return true;

            return false;
        }
    }
}
