namespace InventoryAppDB.View.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SpGetTotalByCustomerId : DbMigration
    {
        public override void Up()
        {
			CreateStoredProcedure(
				"sp_Reports_SumOfTotalsFromInvoicesOfClient",
				p => new
				{
					CustomerId = p.Int()
				},
				body:
				@"SELECT SUM(px.Quantity * p.Price) AS TOTAL
				FROM Invoices i
				JOIN ProdXInvoices px ON px.InvoiceId = i.InvoiceId
				JOIN Products p ON p.ProductId = px.ProductId
				WHERE i.CustomerId = @CustomerId "
			);

		}

		public override void Down()
        {
			DropStoredProcedure("sp_Reports_SumOfTotalsFromInvoicesOfClient");
		}
    }
}
