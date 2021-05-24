using Ecommercewebsite.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecommercewebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandController : ControllerBase
    {
        ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public CommandController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
       



        //POST api/<CommandController>
        [HttpPost]
        public async Task<IActionResult> Post(int PanierId)
        {
            //var user = await _userManager.FindByEmailAsync(login.Email);
            //if (PanierId is null)
            //    throw new ArgumentNullException(nameof(PanierId));

            var panier = _context.Panier.Where(x => x.Id == PanierId).FirstOrDefault();

            if (panier == null)
            {
                NoContent();
            }
            else
            {
                if (panier.commandStatus == false)
                {
                    panier.commandStatus = true;
                    _context.Panier.Update(panier);
                    await _context.SaveChangesAsync();
                    Ok("raja3ha True");


                }
                else
                {
                    Ok("Raha Deja True");
                }
            }



            return Ok("");


        }

       //// PUT api/<CommandController>/5
       // [HttpPut("{id}")]
       // public void Put(int id, [FromBody] string value)
       // {
       // }

       // // DELETE api/<CommandController>/5
       // [HttpDelete("{id}")]
       // public void Delete(int id)
       // {
       // }
    }
}
