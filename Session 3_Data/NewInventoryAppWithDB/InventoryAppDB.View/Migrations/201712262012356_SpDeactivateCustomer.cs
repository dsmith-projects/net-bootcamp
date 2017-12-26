namespace InventoryAppDB.View.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SpDeactivateCustomer : DbMigration
    {
		public override void Up()
		{
			CreateStoredProcedure(
				"sp_Customers_DeactivateCustomer",
				p => new
				{
					CustomerId = p.Int()
				},
				body:
				@"UPDATE Customers SET ActiveCustomer = 0 WHERE CustomerId = @CustomerId"
			);
		}

		public override void Down()
		{
			DropStoredProcedure("sp_Customers_DeactivateCustomer");
		}
	}
}
