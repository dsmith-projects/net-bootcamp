namespace InventoryAppDB.View.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SpDeactivateProduct : DbMigration
    {
		public override void Up()
		{
			CreateStoredProcedure(
				"sp_Products_DeactivateProduct",
				p => new
				{
					ProductId = p.Int()
				},
				body:
				@"UPDATE Products SET ActiveProduct = 0 WHERE ProductId = @ProductId"
			);
		}

		public override void Down()
		{
			DropStoredProcedure("sp_Products_DeactivateProduct");
		}
	}
}
