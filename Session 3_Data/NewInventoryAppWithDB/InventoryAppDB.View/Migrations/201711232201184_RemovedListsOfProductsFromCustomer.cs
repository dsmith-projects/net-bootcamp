namespace InventoryAppDB.View.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedListsOfProductsFromCustomer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Customer_Customer_id", "dbo.Customers");
            DropIndex("dbo.Products", new[] { "Customer_Customer_id" });
            DropColumn("dbo.Products", "Customer_Customer_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Customer_Customer_id", c => c.Int());
            CreateIndex("dbo.Products", "Customer_Customer_id");
            AddForeignKey("dbo.Products", "Customer_Customer_id", "dbo.Customers", "Customer_id");
        }
    }
}
