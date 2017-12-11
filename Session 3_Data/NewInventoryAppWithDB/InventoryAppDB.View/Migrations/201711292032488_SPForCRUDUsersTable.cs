namespace InventoryAppDB.View.Migrations
{
	using System;
	using System.Data.Entity.Migrations;

	public partial class SPForCRUDUsersTable : DbMigration
	{
		public override void Up()
		{

			//CreateStoredProcedure(
			//	"sp_Users_VerifyIfUserIsAdmin",
			//	p => new
			//	{
			//		UserName = p.String(maxLength: 128)
			//	},
			//	body:
			//	@"SELECT Name, IsAdmin FROM Users WHERE Name = @UserName"
			//);

			//CreateStoredProcedure(
			//	"sp_Users_VerifyAdminPassword",
			//	p => new
			//	{
			//		UserName = p.String(maxLength: 128),
			//		Password = p.String(maxLength:32)
			//	},
			//	body:
			//	@"SELECT COUNT(*) FROM Users WHERE Name = @UserName AND Password = Password"
			//);

			//CreateStoredProcedure(
			//	"sp_Users_InsertNewUser",
			//	p => new
			//	{
			//		UserName = p.String(maxLength: 128),
			//		Password = p.String(maxLength: 32),
			//		IsAdmin = p.Boolean()
			//	},
			//	body:
			//	@"INSERT (Name, Password, IsAdmin) VALUES (@UserName, @Password @IsAdmin)"
			//);

			//CreateStoredProcedure(
			//	"sp_Users_DeleteUser",
			//	p => new
			//	{
			//		UserName = p.String(maxLength: 128)
			//	},
			//	body:
			//	@"DELETE Users WHERE (Name = @UserName)"
			//);

			//CreateStoredProcedure(
			//	"sp_Users_UpdateUserPassword",
			//	p => new
			//	{
			//		UserName = p.String(maxLength: 128),
			//		Password = p.String(maxLength: 32)
			//	},
			//	body:
			//	@"UPDATE Users SET Password = @Password WHERE (Name = @UserName)"
			//);

			//CreateStoredProcedure(
			//	"sp_Users_UpdateUserRole",
			//	p => new
			//	{
			//		UserName = p.String(maxLength: 128)
			//	},
			//	body:
			//	@"UPDATE Users SET IsAdmin = 1 WHERE (Name = @UserName)"
			//);

			CreateStoredProcedure(
				"sp_Invoices_GetInvoicesWithinDateRange",
				p => new
				{
					startDate = p.DateTime(),
					endDate = p.DateTime(),
				}, @"SELECT * FROM Invoices WHERE PurchaseDate BETWEEN @startDate AND @endDate"
				);

			
		}

		public override void Down()
		{
			DropStoredProcedure("sp_Invoices_GetInvoicesWithinDateRange");
			//DropStoredProcedure("sp_Users_VerifyIfUserIsAdmin");
			//DropStoredProcedure("sp_Users_VerifyAdminPassword");
			//DropStoredProcedure("sp_Users_InsertNewUser");
			//DropStoredProcedure("sp_Users_DeleteUser");
			//DropStoredProcedure("sp_Users_UpdateUserPassword");
			//DropStoredProcedure("sp_Users_UpdateUserRole");
		}
	}
}
