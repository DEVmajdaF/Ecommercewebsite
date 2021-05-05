using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommercewebsite.Models
{
    public class Panier
    {
        [Key]
        [ForeignKey("userId")]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
      
        public ApplicationUser user { get; set; }
        public string userId { get; set; }
        public bool commandStatus { get; set; }




    }
}
