namespace InventoryAppDB.View.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedFieldNamesToCamelcase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProdXInvoices", "ProductId", "dbo.Products");
            DropPrimaryKey("dbo.Products");
            AddColumn("dbo.Invoices", "PurchaseDate", c => c.DateTime(nullable: false));
			DropColumn("dbo.Products", "Product_id");
			AddColumn("dbo.Products", "ProductId", c => c.Int(nullable: false, identity: true));			
			AddPrimaryKey("dbo.Products", "ProductId");
            AddForeignKey("dbo.ProdXInvoices", "ProductId", "dbo.Products", "ProductId", cascadeDelete: true);
            DropColumn("dbo.Invoices", "Purchase_date");
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Product_id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Invoices", "Purchase_date", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.ProdXInvoices", "ProductId", "dbo.Products");
            DropPrimaryKey("dbo.Products");
            DropColumn("dbo.Products", "ProductId");
            DropColumn("dbo.Invoices", "PurchaseDate");
            AddPrimaryKey("dbo.Products", "Product_id");
            AddForeignKey("dbo.ProdXInvoices", "ProductId", "dbo.Products", "Product_id", cascadeDelete: true);
        }
    }
}
