using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoutiqueEnLigne2.web.Models
{
    public class Client
    {
        [Key]
        public int IdClinet { get; set; }
        public string Nom { get; set; }    
        public string Adresse { get; set; }
        public string Email { get; set;}
        public string Login { get; set;}
        public string Password { get; set;}
        public  ICollection<Commande> Commandes { get; set; }

        public ICollection<Panier> Paniers { get; set; }
        // public virtual Panier Panier { get; set; }
    }
}
