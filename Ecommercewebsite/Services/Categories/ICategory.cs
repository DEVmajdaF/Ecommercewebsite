using System;
using Ecommercewebsite.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommercewebsite.Services.Categories
{
    public interface ICategory
    {

        ////Get
        Task<List<Models.Categorie>> Get();
        ////Get
        Task<Models.Categorie> GetId(string id);
        ////Post
        Task<Models.Categorie> PostCat(Models.Categorie cat);
        ////PUT 
        Task<Models.Categorie> Update(Models.Categorie cat);
        ////Delete 
        Task Delete(string id);


    }
}
