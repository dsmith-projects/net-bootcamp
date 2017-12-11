namespace InventoryAppDB.View.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SPGetInvoicesByCustomerId : DbMigration
    {
        public override void Up()
        {
			CreateStoredProcedure(
				"sp_Invoices_GetInvoicesByCustomerId",
				p => new
				{
					customerId = p.Int()
				},
				body:
				@"SELECT * FROM Invoices WHERE CustomerId = @customerId"
			);
		}
        
        public override void Down()
        {
			DropStoredProcedure("sp_Invoices_GetInvoicesByCustomerId");
		}
	}
}
