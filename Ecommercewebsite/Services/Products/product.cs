using Ecommercewebsite.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommercewebsite.Services.Products
{
    public class product : IProduct
    {
        private readonly ApplicationDbContext _context;

        public product(ApplicationDbContext context)
        {

            _context = context;
        }
        public async Task Delete(string id)
        {
            var deleteproduct = await _context.Product.FindAsync(id);
            _context.Product.Remove(deleteproduct);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetProducts()
        {
            return  _context.Product.ToList();
                 
        }

        //public async Task<Product> GetProducts(string prodid, string categoid)
        //{
        //    if (prodid == string.Empty)
        //    {
        //        throw new ArgumentNullException(nameof(prodid));

        //    }
        //    if (categoid == string.Empty)
        //    {
        //        throw new ArgumentNullException(nameof(categoid));
        //    }
        //    return   _context.Product.Where(a => a.Id == prodid && a.CategorieId== categoid).FirstOrDefault();

        //}

        public async  Task<Product> GetProducts(string id)
        {
            if(id == string.Empty)
                throw new ArgumentNullException(nameof(id));

            return  _context.Product.Where(a=> a.Id == id).FirstOrDefault();
           
        }

        public async Task<List<Product>> GetProductsbycat(string catid)
        {
            if (catid == string.Empty)
                throw new ArgumentNullException(nameof(catid));

            return   _context.Product.Where(a => a.CategorieId == catid).ToList();
        }

        public async  Task<Product> PostProductCat(Product product)
        {
            if (product==null)
            {
                throw new ArgumentNullException(nameof(product));
            }
             var newProduct =  _context.Product.Add(product);
             await _context.SaveChangesAsync();

            return product;
            
        }

        public async  Task<Product> Update(Product product)
        {
            _context.Product.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
