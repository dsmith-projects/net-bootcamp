namespace InventoryAppDB.View.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedActiveProductAndActiveCustomerToEntities : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "ActiveCustomer", c => c.Boolean(nullable: false));
            AddColumn("dbo.Products", "ActiveProduct", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "ActiveProduct");
            DropColumn("dbo.Customers", "ActiveCustomer");
        }
    }
}
