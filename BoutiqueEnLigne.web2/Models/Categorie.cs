﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoutiqueEnLigne2.web.Models
{
    public class Categorie
    {
        public int Id { get; set; }
        public string Nom { get; set; }

        public  ICollection<Produit> Produits { get; set; }
    }
}
