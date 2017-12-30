namespace InventoryAppDB.View.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
	using Entities;
	using InventoryAppDB.Datos;

	internal sealed class Configuration : DbMigrationsConfiguration<InventoryAppDB.Datos.InventoryDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(InventoryDBContext context)
        {
			//  This method will be called after migrating to the latest version.

			//  You can use the DbSet<T>.AddOrUpdate() helper extension method 
			//  to avoid creating duplicate seed data.

			context.Categories.AddOrUpdate(x => x.CategoryId,
				new Category() { CategoryId = 1, Name = "enlatados", Description = "Son productos que vienen en lata. Contienen diferentes tipos de alimentos." },
				new Category() { CategoryId = 2, Name = "bebidas", Description = "Liquidos para consumo" },
				new Category() { CategoryId = 3, Name = "granos", Description = "Granos basicos" },
				new Category() { CategoryId = 4, Name = "cereales", Description = "Todo tipo de cereales" },
				new Category() { CategoryId = 5, Name = "galletas", Description = "Galletas dulces y saladas" },
				new Category() { CategoryId = 6, Name = "bebidas en polvo", Description = "Polvos que se disuelven en agua o leche para crear bebidas" }
				);

			context.Products.AddOrUpdate(x => x.ProductId,
				new Product() { ProductId = 1, ProductName = "Cafe 1820", Price = 1800, AvailQuantity = 500, CategoryId = 6, ActiveProduct = true },
				new Product() { ProductId = 2, ProductName = "Naranitas", Price = 1500, AvailQuantity = 320, CategoryId = 4, ActiveProduct = true },
				new Product() { ProductId = 3, ProductName = "Frijoles negros", Price = 750, AvailQuantity = 1100, CategoryId = 4, ActiveProduct = true },
				new Product() { ProductId = 4, ProductName = "Cremitas", Price = 900, AvailQuantity = 300, CategoryId = 5, ActiveProduct = true }
				);

			context.Customers.AddOrUpdate(x => x.CustomerId,
				new Customer() { CustomerId = 1, FirstName = "Juan", LastName = "Valdez", Telephone = "22224545", Email = "juan.valdez@hotmail.com", ActiveCustomer = true },
				new Customer() { CustomerId = 2, FirstName = "Ana", LastName = "Rogriguez", Telephone = "89568956", Email = "ana.rodriguezz@gmail.com", ActiveCustomer = true },
				new Customer() { CustomerId = 3, FirstName = "Mirna", LastName = "Pereira", Telephone = "42554255", Email = "mirna.p.1987@yahoo.com", ActiveCustomer = true },
				new Customer() { CustomerId = 4, FirstName = "Concepcion", LastName = "Soto", Telephone = "88881111", Email = "concepcion@gmail.com", ActiveCustomer = true },
				new Customer() { CustomerId = 5, FirstName = "Carlos", LastName = "Sanchez", Telephone = "22334455", Email = "carlossanchez2000@gmail.com", ActiveCustomer = true }
				);

			context.Invoices.AddOrUpdate(x => x.InvoiceId,
				new Invoice() { InvoiceId = 1, CustomerId = 5, PurchaseDate = DateTime.Now },
				new Invoice() { InvoiceId = 2, CustomerId = 4, PurchaseDate = DateTime.Now },
				new Invoice() { InvoiceId = 3, CustomerId = 3, PurchaseDate = DateTime.Now },
				new Invoice() { InvoiceId = 4, CustomerId = 2, PurchaseDate = DateTime.Now },
				new Invoice() { InvoiceId = 5, CustomerId = 1, PurchaseDate = DateTime.Now }
				);

			context.ProdXInvoice.AddOrUpdate(x => x.ProdXInvoiceId,
				new ProdXInvoice() { ProdXInvoiceId = 1, InvoiceId = 1, ProductId = 2, Quantity = 3 },
				new ProdXInvoice() { ProdXInvoiceId = 2, InvoiceId = 1, ProductId = 1, Quantity = 1 },
				new ProdXInvoice() { ProdXInvoiceId = 3, InvoiceId = 3, ProductId = 4, Quantity = 2 },
				new ProdXInvoice() { ProdXInvoiceId = 4, InvoiceId = 5, ProductId = 3, Quantity = 3 }
				);

			context.Users.AddOrUpdate(x => x.UserId,
				new User() { UserId = 1, Name = "David", Password = "YWRtaW4xMjM=", IsAdmin = true },
				new User() { UserId = 2, Name = "Steph", Password = "YWRtaW4xMjM=", IsAdmin = true },
				new User() { UserId = 3, Name = "Mitch", Password = "dXNlcg==", IsAdmin = false },
				new User() { UserId = 4, Name = "Martha", Password = "dXNlcg==", IsAdmin = false },
				new User() { UserId = 5, Name = "Christian", Password = "dXNlcg==", IsAdmin = false }
				);

			context.SaveChanges();
		}
    }
}
