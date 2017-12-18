namespace InventoryAppDB.View.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SpUpdateNumberOfProductSupplies : DbMigration
    {
		public override void Up()
		{
			CreateStoredProcedure(
				"sp_Products_UpdateNumberSupplies",
				p => new
				{
					ProductId = p.Int(),
					AvailQuantity = p.Int(),
				},
				body:
				@"UPDATE Products SET AvailQuantity = @availQuantity WHERE ProductId = @productId"
			);
		}

		public override void Down()
		{
			DropStoredProcedure("sp_Products_UpdateNumberSupplies");
		}
	}
}
