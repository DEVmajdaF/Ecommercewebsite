using System;
using System.Collections.Generic;
using Ecommercewebsite.Services.Categories;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ecommercewebsite.Models;

namespace Ecommercewebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ICategory _Icat;

        public CategoriesController(ICategory Icat)
        {
            _Icat = Icat;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categorie>>> GetCategories()
        {
            var getcat= await _Icat.Get();
            return Ok(getcat);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Categorie>> GetCategorie(string id)
        {
            var getcatid = await _Icat.GetId(id);
            return Ok(getcatid);
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategorie(string id, Categorie categorie)
        {
            if (id != categorie.Id)
            {
                return BadRequest();
            }
            var cat = await _Icat.Update(categorie);
            return Ok(cat);
            
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Categorie>> PostCategorie(Categorie categorie)
        {

            if(categorie == null)
            {
                return BadRequest();
            }
            var newcat = await _Icat.PostCat(categorie);
            return Ok(newcat);
          
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategorie(string id)
        {
            var catdel = await _Icat.GetId(id);
            if (catdel == null)
                return NotFound();
            await _Icat.Delete(catdel.Id);
            return NoContent();

        }

      
    }
}
