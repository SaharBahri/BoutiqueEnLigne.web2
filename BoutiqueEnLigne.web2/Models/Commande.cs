using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoutiqueEnLigne2.web.Models
{
    public class Commande
    {
        
        public int Id { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("Client")]
        public int? ClientId { get; set; }
        public Client Client { get; set; }
        public virtual ICollection<ProduitPanier> ProduitsPanier { get; set; }
    }
}
