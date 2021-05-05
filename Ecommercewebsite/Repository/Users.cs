using Ecommercewebsite.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommercewebsite.Repository
{
    public class Users : IUsers
    {

        private readonly ApplicationDbContext _context;
        public Users(ApplicationDbContext context)
        {
            _context = context;
        }

        public async  Task<List<ApplicationUser>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<ApplicationUser> GetUsers(string id)
        {
            return await _context.Users.FindAsync(id);
           
        }

        public async Task Update(ApplicationUser user)
        {
              _context.Users.Update(user);
             await _context.SaveChangesAsync();
            
        }

        public async Task<ApplicationUser> Create(ApplicationUser user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;

        }

        public async Task Delete(string id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(i => i.Id== id);
            _context.Users.Remove(user);
            var save = await _context.SaveChangesAsync();
            
        }
    }
}
