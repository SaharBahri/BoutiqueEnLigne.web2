using BoutiqueEnLigne2.web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BoutiqueEnLigne.web2
{
    public class BoutiqueEnLigne2DbContext : DbContext
    {
        public BoutiqueEnLigne2DbContext() : base("Name=DefaultConnection") { }

        public DbSet<Produit> Produits { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Commande> Commandes { get; set; }
        public DbSet<Panier> Panier { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<ProduitPanier> produitPaniers { get; set; }
    }
}