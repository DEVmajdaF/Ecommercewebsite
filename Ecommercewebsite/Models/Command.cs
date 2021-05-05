using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommercewebsite.Models
{
    public class Command
    {
        [Key]
        [ForeignKey("PanierId,UserId ")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public Panier Panier { get; set; }
        public int PanierId { get; set; }
        public ApplicationUser User { get; set; }
        public string  UserId { get; set; }
        
    }
}
