namespace InventoryAppDB.View.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SpRetrieveUser : DbMigration
    {
		public override void Up()
		{
			CreateStoredProcedure(
				"sp_Users_RetrieveUser",
				p => new
				{
					Name = p.String(),
					Password = p.String()
				},
				body:
				@"SELECT * FROM Users WHERE Name = @Name AND Password = @Password"
			);
		}

		public override void Down()
		{
			DropStoredProcedure("sp_Users_RetrieveUser");
		}
    }
}
