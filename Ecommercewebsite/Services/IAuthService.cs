using Ecommercewebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommercewebsite.Services
{
    public interface IAuthService
    {
        Task<AuthModel> RegisterAsync(RegisterModel Model);
        Task<AuthModel> GetTokenAsync(TokenRequestModel model);
        Task<string> AddRoleAsync(AddRoleModel model);
    }
}
