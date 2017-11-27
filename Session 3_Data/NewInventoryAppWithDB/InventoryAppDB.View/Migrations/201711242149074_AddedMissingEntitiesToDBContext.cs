namespace InventoryAppDB.View.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMissingEntitiesToDBContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProdXInvoices",
                c => new
                    {
                        ProdXInvoiceId = c.Int(nullable: false, identity: true),
                        InvoiceId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProdXInvoiceId)
                .ForeignKey("dbo.Invoices", t => t.InvoiceId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.InvoiceId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false, maxLength: 32),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProdXInvoices", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProdXInvoices", "InvoiceId", "dbo.Invoices");
            DropIndex("dbo.ProdXInvoices", new[] { "ProductId" });
            DropIndex("dbo.ProdXInvoices", new[] { "InvoiceId" });
            DropTable("dbo.Users");
            DropTable("dbo.ProdXInvoices");
        }
    }
}
