namespace InventoryAppDB.View.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Top3ProductsPurchasedByCustomer : DbMigration
    {
		public override void Up()
		{
			CreateStoredProcedure(
				"sp_Reports_Top3ProductsPurchasedByCustomer",
				p => new
				{
					CustomerId = p.Int()
				},
				body:
				@"SELECT top 3 px.ProductId, p.ProductName, SUM(px.Quantity) AS Total_Quantity, c.Name
				FROM ProdXInvoices px
				JOIN Invoices i on i.InvoiceId = px.InvoiceId
				JOIN Products p on p.ProductId = px.ProductId
				JOIN Categories c on p.CategoryId = c.CategoryId
				WHERE i.CustomerId = @CustomerId
				GROUP BY px.ProductId, p.ProductName, c.Name
				ORDER BY Total_Quantity DESC"
			);

		}

		public override void Down()
		{
			DropStoredProcedure("sp_Reports_Top3ProductsPurchasedByCustomer");
		}
	}
}
