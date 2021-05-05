using Ecommercewebsite.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecommercewebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;

        }
        // GET: api/<HomeController>
        [HttpGet]
        public List<Categorie> Get(Categorie categorie)
        {
            return _context.Categories.ToList();
        }

        // GET api/<HomeController>/5
        [HttpGet("{catid}")]
        public List<Product> Get(string catid)
        {
            if (catid == string.Empty)
                throw new ArgumentNullException(nameof(catid));

            return   _context.Product.Where(a => a.CategorieId == catid).ToList();
        }

        //// POST api/<HomeController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<HomeController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<HomeController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
