namespace InventoryAppDB.View.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AverageSpentOnInvoices : DbMigration
    {
        public override void Up()
        {
			CreateStoredProcedure(
				"sp_Reports_AverageSpentOnInvoicesByCustomer2",
				p => new
				{
					CustomerId = p.Int()
				},
				body:
				@"SELECT AVG(TOTAL) AS Average
				FROM
				(
					SELECT c.FirstName, c.LastName, px.InvoiceId, SUM(px.Quantity * p.Price) AS TOTAL
					FROM Invoices i
					JOIN ProdXInvoices px ON px.InvoiceId = i.InvoiceId
					JOIN Customers c ON c.CustomerId = i.CustomerId
					JOIN Products p ON p.ProductId = px.ProductId
					WHERE i.CustomerId = @CustomerId 
					GROUP BY c.FirstName, c.LastName, px.InvoiceId
				) AS InnerTable"
			);
		}
        
        public override void Down()
        {
			DropStoredProcedure("sp_Reports_AverageSpentOnInvoicesByCustomer2");
		}
    }
}
