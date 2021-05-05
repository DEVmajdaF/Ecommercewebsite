using Ecommercewebsite.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommercewebsite.Services.Categories
{
    public class Categories : ICategory
    {
        private readonly ApplicationDbContext _context;
        public Categories(ApplicationDbContext context)
        {
            _context = context;

        }
        public async Task Delete(string id)
        {
            var catdel= await _context.Categories.FindAsync(id);
            _context.Categories.Remove(catdel);
            await _context.SaveChangesAsync();
        }

        public async  Task<List<Models.Categorie>> Get()
        {
           return  _context.Categories.ToList();
           
        }

        public async  Task<Models.Categorie> GetId(string id)
        {
           return await _context.Categories.FindAsync(id);
         

        }

        public async Task<Models.Categorie> PostCat(Models.Categorie cat)
        {
            var newcat = _context.Categories.Add(cat);
            await _context.SaveChangesAsync();
            return cat;
        }

        public async  Task<Models.Categorie> Update(Models.Categorie cat)
        {
            _context.Categories.Update(cat);
            await _context.SaveChangesAsync();
            return cat;
        }
    }
}
