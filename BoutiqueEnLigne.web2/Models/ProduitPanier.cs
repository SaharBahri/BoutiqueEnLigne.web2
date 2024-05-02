using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoutiqueEnLigne2.web.Models
{
    public class ProduitPanier

    {
        [Key]
        public int Id { get; set; }
        public int ProduitId { get; set; }
        [ForeignKey("Panier")]
        public int? PanierId { get; set; }
        public Panier Panier { get; set; }
        //public int PanierId { get; set; }
        public int Quantite { get; set; }

        [ForeignKey("Commande")]
        public int? CommandeId { get; set; }
        public Commande Commande { get; set; }


        /*public virtual Produit Produit { get; set; }
        public virtual Panier Panier { get; set; }*/
    }
}
