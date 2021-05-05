using System;
using Ecommercewebsite.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Ecommercewebsite.Services.Products
{
    public interface IProduct
    {
        ////Get
        Task<List<Product>> GetProducts();
        ////Get
        Task<Product> GetProducts(string id);
        ////Get
        Task<List<Product>> GetProductsbycat(string catid);
        ////Post
        Task<Product> PostProductCat(Product product);
        ////PUT 
        Task<Product> Update(Product product);
        ////Delete 
        Task Delete(string id);



    }
}
