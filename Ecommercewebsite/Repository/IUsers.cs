using Ecommercewebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommercewebsite.Repository
{
    public interface IUsers
    {
        Task<List<ApplicationUser>> GetUsers();
        Task<ApplicationUser> GetUsers(string id );
        Task<ApplicationUser> Create(ApplicationUser user);
        Task Update(ApplicationUser user);
        Task Delete(string id);
    }
}
