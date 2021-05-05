using Ecommercewebsite.Services.Products;
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
    public class ProductController : ControllerBase
    {
        IProduct _product;
        public ProductController(IProduct product)
        {
            _product = product;
        }


        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var getproduct = await _product.GetProducts();
            return Ok(getproduct);
        }

        

        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(string id)
        //{
        //    var getproduct = await _product.GetProducts(id);
        //    return Ok(getproduct);
        //}

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var getproduct = await _product.GetProducts(id);
            return Ok(getproduct);
        }



        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest();

            }
            var newproduct = await _product.PostProductCat(product);
            return Ok(newproduct);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id,[FromBody] Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }
            var newproduct = await _product.Update(product);
            return Ok(newproduct);

        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {

            var productToDelete = await _product.GetProducts(id);
            if (productToDelete == null)
                return NotFound();
            await _product.Delete(productToDelete.Id);
            return NoContent(); 
        }
    }
}
