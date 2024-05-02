using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoutiqueEnLigne2.web.Models
{
    public class Produit
    {
        public int Id { get; set; }    
        public string Nom { get; set; }
        public float Prix { get; set; }

        public string Description { get; set; }
        public int Stock { get; set; }

        [ForeignKey("Categorie")]
        public int? CategorieId { get; set; }
        public  Categorie Categorie { get; set; }
        
    }
}
