namespace InventoryAppDB.View.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SpUpdateCustomerInfo : DbMigration
    {
        public override void Up()
        {
			CreateStoredProcedure(
				"sp_Products_UpdateCustomerInformation",
				p => new
				{
					CustomerId = p.Int(),
					FirstName = p.String(),
					LastName = p.String(),
					Telephone = p.String(),
					Email = p.String()
				},
				body:
				@"UPDATE Customers SET FirstName = @firstName, LastName = @lastName, Telephone = @telephone, Email = @email WHERE CustomerId = @customerId"
			);
		}
        
        public override void Down()
        {
			DropStoredProcedure("sp_Products_UpdateCustomerInformation");
		}
    }
}
