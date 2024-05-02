using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoutiqueEnLigne2.web.Models
{
    public class Panier
    {
        [Key]
        public int IdPanier { get; set; }

        [ForeignKey("Client")]
        public int? ClientId { get; set; }
        public Client Client { get; set; }
        //public virtual Client Client { get; set; }

        [InverseProperty("Panier")]
        public virtual ICollection<ProduitPanier> ProduitsPanier { get; set; }

    }
}
