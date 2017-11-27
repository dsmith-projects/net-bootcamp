namespace InventoryAppDB.View.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Customer_id = c.Int(nullable: false, identity: true),
                        First_name = c.String(nullable: false, maxLength: 128),
                        Last_name = c.String(nullable: false, maxLength: 128),
                        Telephone = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Customer_id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Product_id = c.Int(nullable: false, identity: true),
                        Product_name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Avail_quantity = c.Int(nullable: false),
                        Category = c.String(),
                        Customer_Customer_id = c.Int(),
                        Invoice_Customer_id = c.Int(),
                        Invoice_Product_id = c.Int(),
                    })
                .PrimaryKey(t => t.Product_id)
                .ForeignKey("dbo.Customers", t => t.Customer_Customer_id)
                .ForeignKey("dbo.Invoices", t => new { t.Invoice_Customer_id, t.Invoice_Product_id })
                .Index(t => t.Customer_Customer_id)
                .Index(t => new { t.Invoice_Customer_id, t.Invoice_Product_id });
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Customer_id = c.Int(nullable: false),
                        Product_id = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Purchase_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.Customer_id, t.Product_id })
                .ForeignKey("dbo.Customers", t => t.Customer_id, cascadeDelete: true)
                .Index(t => t.Customer_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", new[] { "Invoice_Customer_id", "Invoice_Product_id" }, "dbo.Invoices");
            DropForeignKey("dbo.Invoices", "Customer_id", "dbo.Customers");
            DropForeignKey("dbo.Products", "Customer_Customer_id", "dbo.Customers");
            DropIndex("dbo.Invoices", new[] { "Customer_id" });
            DropIndex("dbo.Products", new[] { "Invoice_Customer_id", "Invoice_Product_id" });
            DropIndex("dbo.Products", new[] { "Customer_Customer_id" });
            DropTable("dbo.Invoices");
            DropTable("dbo.Products");
            DropTable("dbo.Customers");
        }
    }
}
