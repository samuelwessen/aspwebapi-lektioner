using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiWithAuth.Models;

namespace WebApiWithAuth.Services
{
    public interface IIdentityService
    {
        Task<bool> CreateUserAsync(SignUp model);
        Task<SignInResponse> SignInAsync(string email, string password);

        Task<IEnumerable<UserResponse>> GetUsersAsync();

        bool ValidateAccessRights(RequestUser requestUser);

    }
}
