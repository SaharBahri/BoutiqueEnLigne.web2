namespace BoutiqueEnLigne.web2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Produits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Prix = c.Single(nullable: false),
                        Description = c.String(),
                        Stock = c.Int(nullable: false),
                        Categorie_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Categorie_Id)
                .Index(t => t.Categorie_Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        IdClinet = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Adresse = c.String(),
                        Email = c.String(),
                        Login = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.IdClinet);
            
            CreateTable(
                "dbo.Commandes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Client_IdClinet = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_IdClinet)
                .Index(t => t.Client_IdClinet);
            
            CreateTable(
                "dbo.ProduitPaniers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProduitId = c.Int(nullable: false),
                        PanierId = c.Int(nullable: false),
                        Quantite = c.Int(nullable: false),
                        Panier_IdPanier = c.Int(),
                        Commande_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Paniers", t => t.Panier_IdPanier)
                .ForeignKey("dbo.Produits", t => t.ProduitId, cascadeDelete: true)
                .ForeignKey("dbo.Commandes", t => t.Commande_Id)
                .Index(t => t.ProduitId)
                .Index(t => t.Panier_IdPanier)
                .Index(t => t.Commande_Id);
            
            CreateTable(
                "dbo.Paniers",
                c => new
                    {
                        IdPanier = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdPanier)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProduitPaniers", "Commande_Id", "dbo.Commandes");
            DropForeignKey("dbo.ProduitPaniers", "ProduitId", "dbo.Produits");
            DropForeignKey("dbo.ProduitPaniers", "Panier_IdPanier", "dbo.Paniers");
            DropForeignKey("dbo.Paniers", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Commandes", "Client_IdClinet", "dbo.Clients");
            DropForeignKey("dbo.Produits", "Categorie_Id", "dbo.Categories");
            DropIndex("dbo.Paniers", new[] { "ClientId" });
            DropIndex("dbo.ProduitPaniers", new[] { "Commande_Id" });
            DropIndex("dbo.ProduitPaniers", new[] { "Panier_IdPanier" });
            DropIndex("dbo.ProduitPaniers", new[] { "ProduitId" });
            DropIndex("dbo.Commandes", new[] { "Client_IdClinet" });
            DropIndex("dbo.Produits", new[] { "Categorie_Id" });
            DropTable("dbo.Paniers");
            DropTable("dbo.ProduitPaniers");
            DropTable("dbo.Commandes");
            DropTable("dbo.Clients");
            DropTable("dbo.Produits");
            DropTable("dbo.Categories");
        }
    }
}
