using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommercewebsite.Models
{
    public class PanierDetails
    {
       
        [ForeignKey("productId , panierId , userid")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public DateTime date { get; set; }
        public int  Quantity { get; set; }
        public double TotalPrice { get; set; }

        public Panier panier { get; set; }
        public int panierId { get; set; }

        public ApplicationUser user { get; set; }
        public string userid { get; set; }

        public Product product { get; set; }
        public string productId { get; set; }

    }
}
