namespace InventoryAppDB.View.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedListsFromInvoices : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", new[] { "Invoice_Customer_id", "Invoice_Product_id" }, "dbo.Invoices");
            DropIndex("dbo.Products", new[] { "Invoice_Customer_id", "Invoice_Product_id" });
            CreateIndex("dbo.Invoices", "Product_id");
            AddForeignKey("dbo.Invoices", "Product_id", "dbo.Products", "Product_id", cascadeDelete: true);
            DropColumn("dbo.Products", "Invoice_Customer_id");
            DropColumn("dbo.Products", "Invoice_Product_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Invoice_Product_id", c => c.Int());
            AddColumn("dbo.Products", "Invoice_Customer_id", c => c.Int());
            DropForeignKey("dbo.Invoices", "Product_id", "dbo.Products");
            DropIndex("dbo.Invoices", new[] { "Product_id" });
            CreateIndex("dbo.Products", new[] { "Invoice_Customer_id", "Invoice_Product_id" });
            AddForeignKey("dbo.Products", new[] { "Invoice_Customer_id", "Invoice_Product_id" }, "dbo.Invoices", new[] { "Customer_id", "Product_id" });
        }
    }
}
