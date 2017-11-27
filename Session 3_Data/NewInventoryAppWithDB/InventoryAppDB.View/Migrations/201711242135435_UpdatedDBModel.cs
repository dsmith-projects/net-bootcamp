namespace InventoryAppDB.View.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedDBModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Invoices", "Product_id", "dbo.Products");
            DropForeignKey("dbo.Invoices", "Customer_id", "dbo.Customers");
            DropIndex("dbo.Invoices", new[] { "Product_id" });
            RenameColumn(table: "dbo.Invoices", name: "Customer_id", newName: "CustomerId");
            RenameIndex(table: "dbo.Invoices", name: "IX_Customer_id", newName: "IX_CustomerId");
            DropPrimaryKey("dbo.Customers");
            DropPrimaryKey("dbo.Invoices");
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);

			DropColumn("dbo.Customers", "Customer_id");
			AddColumn("dbo.Customers", "CustomerId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Customers", "FirstName", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Customers", "LastName", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Invoices", "InvoiceId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Products", "ProductName", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Products", "AvailQuantity", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "CategoryId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Customers", "CustomerId");
            AddPrimaryKey("dbo.Invoices", "InvoiceId");
            CreateIndex("dbo.Products", "CategoryId");
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "CategoryId", cascadeDelete: true);
            AddForeignKey("dbo.Invoices", "CustomerId", "dbo.Customers", "CustomerId", cascadeDelete: true);            
            DropColumn("dbo.Customers", "First_name");
            DropColumn("dbo.Customers", "Last_name");
            DropColumn("dbo.Invoices", "Product_id");
            DropColumn("dbo.Invoices", "Quantity");
            DropColumn("dbo.Products", "Product_name");
            DropColumn("dbo.Products", "Avail_quantity");
            DropColumn("dbo.Products", "Category");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Category", c => c.String());
            AddColumn("dbo.Products", "Avail_quantity", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "Product_name", c => c.String());
            AddColumn("dbo.Invoices", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.Invoices", "Product_id", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "Last_name", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Customers", "First_name", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Customers", "Customer_id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Invoices", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropPrimaryKey("dbo.Invoices");
            DropPrimaryKey("dbo.Customers");
            DropColumn("dbo.Products", "CategoryId");
            DropColumn("dbo.Products", "AvailQuantity");
            DropColumn("dbo.Products", "ProductName");
            DropColumn("dbo.Invoices", "InvoiceId");
            DropColumn("dbo.Customers", "LastName");
            DropColumn("dbo.Customers", "FirstName");
            DropColumn("dbo.Customers", "CustomerId");
            DropTable("dbo.Categories");
            AddPrimaryKey("dbo.Invoices", new[] { "Customer_id", "Product_id" });
            AddPrimaryKey("dbo.Customers", "Customer_id");
            RenameIndex(table: "dbo.Invoices", name: "IX_CustomerId", newName: "IX_Customer_id");
            RenameColumn(table: "dbo.Invoices", name: "CustomerId", newName: "Customer_id");
            CreateIndex("dbo.Invoices", "Product_id");
            AddForeignKey("dbo.Invoices", "Customer_id", "dbo.Customers", "Customer_id", cascadeDelete: true);
            AddForeignKey("dbo.Invoices", "Product_id", "dbo.Products", "Product_id", cascadeDelete: true);
        }
    }
}
