using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommercewebsite.Models
{
    public class ApplicationDbContext :IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {


        }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Command> Commande { get; set; }
        public DbSet<Panier> Panier { get; set; }
        public DbSet<PanierDetails> PanierDetails { get; set; }
        public DbSet<Product> Product { get; set; }
      
        
    }
}
