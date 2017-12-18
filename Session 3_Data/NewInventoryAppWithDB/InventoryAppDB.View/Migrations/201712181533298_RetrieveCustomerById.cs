namespace InventoryAppDB.View.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RetrieveCustomerById : DbMigration
    {
        public override void Up()
        {
			CreateStoredProcedure(
				"sp_Customers_RetrieveCustomerById",
				p => new
				{
					CustomerId = p.Int()
				},
				body:
				@"SELECT * FROM Customers WHERE CustomerId = @customerId"
			);
		}
        
        public override void Down()
        {
			DropStoredProcedure("sp_Customers_RetrieveCustomerById");
		}
    }
}
