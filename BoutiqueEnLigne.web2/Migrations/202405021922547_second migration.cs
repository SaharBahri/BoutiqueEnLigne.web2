namespace BoutiqueEnLigne.web2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondmigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProduitPaniers", "ProduitId", "dbo.Produits");
            DropForeignKey("dbo.Paniers", "ClientId", "dbo.Clients");
            DropIndex("dbo.ProduitPaniers", new[] { "ProduitId" });
            DropIndex("dbo.ProduitPaniers", new[] { "Panier_IdPanier" });
            DropIndex("dbo.Paniers", new[] { "ClientId" });
            DropColumn("dbo.ProduitPaniers", "PanierId");
            RenameColumn(table: "dbo.Produits", name: "Categorie_Id", newName: "CategorieId");
            RenameColumn(table: "dbo.Commandes", name: "Client_IdClinet", newName: "ClientId");
            RenameColumn(table: "dbo.ProduitPaniers", name: "Commande_Id", newName: "CommandeId");
            RenameColumn(table: "dbo.ProduitPaniers", name: "Panier_IdPanier", newName: "PanierId");
            RenameIndex(table: "dbo.Produits", name: "IX_Categorie_Id", newName: "IX_CategorieId");
            RenameIndex(table: "dbo.Commandes", name: "IX_Client_IdClinet", newName: "IX_ClientId");
            RenameIndex(table: "dbo.ProduitPaniers", name: "IX_Commande_Id", newName: "IX_CommandeId");
            AlterColumn("dbo.ProduitPaniers", "PanierId", c => c.Int());
            AlterColumn("dbo.Paniers", "ClientId", c => c.Int());
            CreateIndex("dbo.ProduitPaniers", "PanierId");
            CreateIndex("dbo.Paniers", "ClientId");
            AddForeignKey("dbo.Paniers", "ClientId", "dbo.Clients", "IdClinet");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Paniers", "ClientId", "dbo.Clients");
            DropIndex("dbo.Paniers", new[] { "ClientId" });
            DropIndex("dbo.ProduitPaniers", new[] { "PanierId" });
            AlterColumn("dbo.Paniers", "ClientId", c => c.Int(nullable: false));
            AlterColumn("dbo.ProduitPaniers", "PanierId", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.ProduitPaniers", name: "IX_CommandeId", newName: "IX_Commande_Id");
            RenameIndex(table: "dbo.Commandes", name: "IX_ClientId", newName: "IX_Client_IdClinet");
            RenameIndex(table: "dbo.Produits", name: "IX_CategorieId", newName: "IX_Categorie_Id");
            RenameColumn(table: "dbo.ProduitPaniers", name: "PanierId", newName: "Panier_IdPanier");
            RenameColumn(table: "dbo.ProduitPaniers", name: "CommandeId", newName: "Commande_Id");
            RenameColumn(table: "dbo.Commandes", name: "ClientId", newName: "Client_IdClinet");
            RenameColumn(table: "dbo.Produits", name: "CategorieId", newName: "Categorie_Id");
            AddColumn("dbo.ProduitPaniers", "PanierId", c => c.Int(nullable: false));
            CreateIndex("dbo.Paniers", "ClientId");
            CreateIndex("dbo.ProduitPaniers", "Panier_IdPanier");
            CreateIndex("dbo.ProduitPaniers", "ProduitId");
            AddForeignKey("dbo.Paniers", "ClientId", "dbo.Clients", "IdClinet", cascadeDelete: true);
            AddForeignKey("dbo.ProduitPaniers", "ProduitId", "dbo.Produits", "Id", cascadeDelete: true);
        }
    }
}
