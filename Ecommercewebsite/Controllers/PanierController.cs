using Ecommercewebsite.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Authentication;
using System.Security.Claims;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecommercewebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PanierController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        ApplicationDbContext _context;
        public PanierController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }


        // POST api/<PanierController>
        //Delete Product 
        [HttpPost("{id}")]
        public async Task<IActionResult> Post(string id, RegisterModel login, int quantity )
        {

            var user = await _userManager.FindByEmailAsync(login.Email);

            if (id == string.Empty)
                throw new ArgumentNullException(nameof(id));
            //var user = new RegisterModel();
            //add new panierwhen we add a new product 
           ;
            //db.Users.OrderByDescending(u => u.UserId).FirstOrDefault();
            //var useridauth = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var existpanier = _context.Panier.Where(a=>a.userId== user.Id).ToList();

            if (existpanier.Count==0 )
            {
                Panier panier = new Panier();
                panier.userId = user.Id;
                panier.commandStatus = false;
                _context.Panier.Add(panier);
                await _context.SaveChangesAsync();

                var p = _context.Product.Where(a => a.Id == id).FirstOrDefault();
                if (p == null)
                    throw new ArgumentNullException(nameof(p));

                // int intIdt = db.Users.Max(u => u.UserId);

                PanierDetails panierd = new PanierDetails();



                //The id of the user authenticated;
                panierd.userid = user.Id;
                panierd.date = DateTime.Today;
                panierd.productId = id;
                panierd.panierId = panier.Id;
                panierd.Quantity = quantity;
                _context.PanierDetails.Add(panierd);
                await _context.SaveChangesAsync();
          



            }
            else
            {
                var lastid = _context.Panier.Where(a => a.userId == user.Id).OrderByDescending(a => a.Id).FirstOrDefault();

                //var lastid = _context.Panier.Where(a => a.userId == user.Id).Max(s => s.Id).SingleOrDefault();
                if (lastid.commandStatus==false)
                {

                    var p = _context.Product.Where(a => a.Id == id).FirstOrDefault();
                    if (p == null)
                        throw new ArgumentNullException(nameof(p));

                    // int intIdt = db.Users.Max(u => u.UserId);

                    PanierDetails panierd = new PanierDetails();



                    //The id of the user authenticated;
                    panierd.userid = user.Id;
                    panierd.date = DateTime.Today;
                    panierd.productId = id;
                    panierd.panierId = lastid.Id;
                    panierd.Quantity = quantity;
                    _context.PanierDetails.Add(panierd);
                    await _context.SaveChangesAsync();
                   




                }
                else
                {

                    Panier panier = new Panier();
                    panier.userId = user.Id;
                    panier.commandStatus = false;
                    _context.Panier.Add(panier);
                    await _context.SaveChangesAsync();


                    var p = _context.Product.Where(a => a.Id == id).FirstOrDefault();
                    if (p == null)
                        throw new ArgumentNullException(nameof(p));

                    // int intIdt = db.Users.Max(u => u.UserId);

                    PanierDetails panierd = new PanierDetails();



                    //The id of the user authenticated;
                    panierd.userid = user.Id;
                    panierd.date = DateTime.Today;
                    panierd.productId = id;
                    panierd.panierId = panier.Id;
                    panierd.Quantity = quantity;
                    _context.PanierDetails.Add(panierd);
                    await _context.SaveChangesAsync();
            



                }
            }  
            return Ok();
        }


        //Delete Product 
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
         
            if (id == string.Empty)
                throw new ArgumentNullException(nameof(id));

            var p = _context.PanierDetails.Where(a => a.productId == id).FirstOrDefault();
            if (p==null)
            {
                throw new ArgumentNullException(nameof(p));
            }

            _context.PanierDetails.Remove(p);
            await _context.SaveChangesAsync();
            return Ok(p);
        }


        //public double totalPrice(int id)
        //{



        //    var total = _context.PanierDetails.Where(a => a.panierId == id).Sum(q => q.Quantity * q.product.Price);

        //    return (total);


        //}




    }
}
