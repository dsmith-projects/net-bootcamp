using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryAppDB.Logica;
using Entities;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Globalization;

namespace InventoryAppDB.Interfaz
{
	public class InputOutputData
	{
		static InventoryLogic inventoryLogic = new InventoryLogic();
		
		public void DisplayLoginMessage()
		{
			Console.WriteLine(">>> Please log in: \n");
		}

		public string RequestUsername()
		{
			Console.Write("Username: ");
			string username = Console.ReadLine();
			return username;
		}

		public string RequestPassword()
		{
			Console.Write("Password: ");
			string password = Console.ReadLine();
			return password;
		}

		public User RetrieveUser(string username, string password)
		{
			User user = inventoryLogic.RetrieveUser(username, password);
			return user;
		}

		public bool VerifyCredentialsAreCorrect(User user)
		{
			//Console.WriteLine("User: {0}", user);
			if (user == null)
			{
				//Console.WriteLine("Is null!!!!");
				return false;
			}
			return true;
		}

		public void DisplayMessageIncorrectCredentials(int numberAttempts)
		{
			Console.Write("\nIncorrect username or password. ");
			Console.WriteLine("You have {0} attempts left.", numberAttempts);
			Console.WriteLine();
		}

		public bool UserIsAdmin(User user)
		{
			return user.IsAdmin;
		}

		public void DisplayMessageLockedAccount()
		{
			Console.WriteLine();
			Console.WriteLine(">>> The program has been locked. You reached the maximum number of attempts!");
			Console.WriteLine();
			Console.WriteLine(">>> Press any key to exit");
			Console.ReadKey();
			Console.Clear();
		}


		public void WelcomeUser()
		{
			Console.WriteLine("WELCOME TO THE INVENTORY PROGRAM\n");
		}

		public void LoginMessageUser()
		{
			Console.WriteLine("You have signed in as USER\n");
		}
		public void DisplayUserMenu()
		{
			Console.WriteLine("**** MAIN MENU *****");
			Console.WriteLine();
			Console.WriteLine("1. LIST inventory items");
			Console.WriteLine("2. CREATE new invoice");
			Console.WriteLine("3. DISPLAY invoices report between two dates");
			Console.WriteLine("4. DISPLAY invoices report per customer id");
			Console.WriteLine("5. EXIT application");
			Console.WriteLine();
		}
		public int ChooseAnOption(int lastMenuOption)
		{
			int option = 0;
			string input;
			bool isNumber;
			bool repeatMenu = false;

			do
			{
				Console.WriteLine();
				Console.Write("Choose an option: ");
				input = Console.ReadLine();
				isNumber = Int32.TryParse(input, out option);
				if (!isNumber)
				{
					Console.WriteLine(">>> Invalid input. Please try again!\n");
					repeatMenu = true;
				}
				if (option < 1 || option > lastMenuOption)
				{
					Console.WriteLine(">>> Option not available. Please try again!\n");
					repeatMenu = true;
				}
			} while (repeatMenu);

			return option;
		}

		public void LoginMessageAdmin()
		{
			Console.WriteLine("You have signed in as ADMIN\n");
		}
		public void DisplayAdminMenu()
		{
			Console.WriteLine("**** MAIN MENU ****");
			Console.WriteLine();
			Console.WriteLine("1. LIST inventory items");
			Console.WriteLine("2. ADD a new item to the inventory");
			Console.WriteLine("3. MODIFY the number of product supplies");
			Console.WriteLine("4. REMOVE an item from the inventory");
			Console.WriteLine("5. CREATE new product category");
			Console.WriteLine("6. ADD new customer");
			Console.WriteLine("7. EDIT customer information");
			Console.WriteLine("8. REMOVE customer by id");
			Console.WriteLine("9. EXIT application");
		}

		public void DisplayInitializationParameterError()
		{
			Console.WriteLine(">>> Incorrect login parameter. If you want to run the app as an administrator enter parameter \'admin\' when running the app in the console.\nIf you want to run the app as a user do not enter any parameters when running the app.");
		}

		public void DisplayExitMessage()
		{
			Console.Clear();
			Console.WriteLine(">>> You have exited the application. Have a great day!");
		}


		// STARTS PRODUCT METHODS

		public void ListInventoryItems()
		{
			//InventoryLogic inventoryLogic = new InventoryLogic();
			List<Product> listProducts = inventoryLogic.ListInventoryItems().ToList();

			//Console.WriteLine("PRODUCT ID\tNAME\t\t\tPRICE\t\tAVAILABLE SUPPLIES\tCATEGORY");

			//foreach (var item in listProducts)
			//{
			//Console.WriteLine($"{item.ProductId}\t\t{item.ProductName}\t\t{item.Price}\t\t{item.AvailQuantity}\t\t\t{item.CategoryId}");
			//}

			string line = "";
			string header = "PRODUCT ID".PadRight(12) + "NAME".PadRight(25) + "PRICE".PadRight(15) + "No. SUPPLIES".PadRight(17) + "CATEGORY".PadRight(20);

			Console.WriteLine(header);

			foreach (var item in listProducts)
			{
				line += item.ProductId.ToString().PadRight(12);
				line += item.ProductName.PadRight(25);
				line += item.Price.ToString().PadRight(15);
				line += item.AvailQuantity.ToString().PadRight(17);
				line += item.CategoryId.ToString().PadRight(20);
				Console.WriteLine(line);
				line = "";
			}
		}

		public void PressAnyKeyToContinue()
		{
			Console.WriteLine();
			Console.WriteLine(">>> Press any key to continue...");
			Console.ReadKey();
			Console.Clear();
		}

		public Product CreateNewProduct()
		{
			string productName = "";
			decimal price = 0;
			int quantity = 0;
			int category = 0;
			bool activeProduct = true;

			Console.WriteLine("Please provide the following information:\n");

			productName = GetProductName();
			price = GetProductPrice();
			quantity = GetProductQuantity();

			DisplayMessageToChooseCategory();

			DisplayProductCategories();

			category = ChooseProductCategory();

			Product newProduct = new Product
			{
				ProductName = productName,
				Price = price,
				AvailQuantity = quantity,
				CategoryId = category,
				ActiveProduct = activeProduct
			};

			return newProduct;
		}

		private string GetProductName()
		{
			Console.Write("Product name: ");
			string product_name = Console.ReadLine();
			return product_name;
		}

		private decimal GetProductPrice()
		{
			decimal price = 0;
			bool convertedToDecimal;

			do
			{
				Console.Write("Price: ");
				convertedToDecimal = Decimal.TryParse(Console.ReadLine(), out price);

				if (!convertedToDecimal)
				{
					Console.WriteLine(">>> Incorrect value. Please try again:\n");
				}
			} while (!convertedToDecimal);

			return price;
		}

		public int GetProductQuantity()
		{
			int quantity = 0;
			bool convertedToInteger;

			do
			{
				Console.Write("Quantity: ");
				convertedToInteger = Int32.TryParse(Console.ReadLine(), out quantity);

				if (!convertedToInteger)
				{
					Console.WriteLine(">>> Incorrect value. Please try again:\n");
				}
			} while (!convertedToInteger);

			return quantity;
		}

		public void DisplayMessageToChooseCategory()
		{
			Console.WriteLine();
			Console.WriteLine(">>> Please choose a category id from the list: ");
			Console.WriteLine();
		}

		private void DisplayProductCategories()
		{
			//Console.WriteLine();
			List<Category> listCategories = inventoryLogic.ListCategories().ToList();

			string line = "";
			string header = "CATEGORY ID".PadRight(20) + "NAME".PadRight(25) + "DESCRIPTION".PadRight(50);

			Console.WriteLine(header);

			foreach (var item in listCategories)
			{
				line += item.CategoryId.ToString().PadRight(20);
				line += item.Name.PadRight(25);
				line += item.Description.PadRight(50);
				Console.WriteLine(line);
				line = "";
			}
		}

		private int ChooseProductCategory()
		{
			int category = 0;
			bool convertedToInteger = false;
			bool validCategory = false;

			do
			{
				Console.WriteLine();
				Console.Write("Please choose a product category: ");
				convertedToInteger = Int32.TryParse(Console.ReadLine(), out category);

				if (convertedToInteger)
				{
					validCategory = VerifyIfProductCategoryIsValid(category);

					if (!validCategory)
					{
						Console.WriteLine(">>> Invalid category number. Please try again:\n");
					}
				}
				else
				{
					Console.WriteLine();
					Console.WriteLine(">>> Incorrect value. Please try again:");
				}


			} while (!convertedToInteger || !validCategory);

			return category;
		}

		private bool VerifyIfProductCategoryIsValid(int inputCategory)
		{
			Console.WriteLine("\nto do: verify if category number is within range");
			bool validCategory = true;
			return validCategory;
		}


		public void DisplayMessageToListProductsInInventory()
		{
			Console.Clear();
			Console.WriteLine(">>> Products in the inventory: ");
			Console.WriteLine();
		}

		public void DisplayMessageToAddNewProduct()
		{
			Console.Clear();
			Console.WriteLine(">>> Add new product to inventory: ");
			Console.WriteLine();
		}

		public void AddNewProduct(Product newProduct)
		{
			// Add new product 
			Console.WriteLine();
			Console.WriteLine("Adding new product to the inventory... ");
			Console.WriteLine();

			inventoryLogic.AddNewProduct(newProduct);
			Console.WriteLine(">>> Product successfully added to inventory");			
		}

		public void DisplayMessageToDeleteProduct()
		{
			Console.Clear();
			Console.WriteLine(">>> Delete product from inventory: ");
			Console.WriteLine();
		}

		public void DisplayMessageToEditProductSupplies()
		{
			Console.Clear();
			Console.WriteLine(">>> Edit product's available supplies: ");
			Console.WriteLine();
		}

		public void ModifyProductAvailableSupplies(int productId)
		{
			int quantity = 0;
			Console.WriteLine(">>> Modifying # of product supplies. Provide updated data:");
			Console.WriteLine();
			quantity = GetProductQuantity();
			
			Console.WriteLine();
			inventoryLogic.ModifyProductAvailableSupplies(productId, quantity);

			Console.WriteLine(">>> Number of supplies successfully updated");
		}

		public int DisplayMessageToChooseProduct()
		{
			int productId = 0;
			bool convertedToInteger = false;
			bool validProductId = false;

			do
			{
				Console.WriteLine();
				Console.Write(">>> Please input the product id: ");
				convertedToInteger = Int32.TryParse(Console.ReadLine(), out productId);

				if (convertedToInteger)
				{
					validProductId = VerifyIfProductIdIsValid(productId);

					if (!validProductId)
					{
						Console.WriteLine(">>> Invalid customer id. Please try again:\n");
					}
				}
				else
				{
					Console.WriteLine(">>> Incorrect value. Please try again:\n");
				}
			} while (!convertedToInteger || !validProductId);

			return productId;
		}

		public bool VerifyIfProductIdIsValid(int productId)
		{
			Console.WriteLine("\n to do: verify if product id is within range \n");
			bool validProductId = true;

			if (!validProductId)
			{
				DisplayMessageInvalidProductId();
			}


			return validProductId;
		}

		public void DisplayMessageInvalidProductId()
		{
			Console.WriteLine("\nThe product id you entered does not exist in our records.");
		}

		public void RemoveProductById(int productId)
		{			
			Console.WriteLine(">>> Removing product by id...\n");
			inventoryLogic.RemoveProductById(productId);
			Console.WriteLine(">>> Product successfully removed from inventory");
		}

		public int GetProductId()
		{
			int pId = 0;
			bool convertedToInteger;

			do
			{
				Console.Write("Product id: ");
				convertedToInteger = Int32.TryParse(Console.ReadLine(), out pId);

				if (!convertedToInteger)
				{
					Console.WriteLine(">>> Incorrect value. Please try again:\n");
				}
			} while (!convertedToInteger);

			return pId;
		}

		public void DisplayMessageToCreateNewCategory()
		{
			Console.Clear();
			Console.WriteLine(">>> Create a new product category: ");
			Console.WriteLine();
		}

		public Category CreateNewProductCategory()
		{
			string category = "";
			string description = "";

			Console.WriteLine("Please provide the following information:\n");

			category = GetCategoryName();
			description = GetCategoryDescription();

			Category newCategory = new Category
			{
				Name = category,
				Description = description
			};

			return newCategory;
		}

		private string GetCategoryName()
		{
			Console.Write("Category name: ");
			string categoryName = Console.ReadLine();
			return categoryName;
		}

		private string GetCategoryDescription()
		{
			Console.Write("Category description: ");
			string categoryDescription = Console.ReadLine();
			return categoryDescription;
		}

		public void AddNewCategory(Category newCategory)
		{
			// Add new product category 
			Console.WriteLine();
			Console.WriteLine("Creating new product category... ");
			Console.WriteLine();

			inventoryLogic.AddNewCategory(newCategory);
			Console.WriteLine(">>> Category successfully created");
		}


		// ENDS PRODUCTS METHODS

		// STARTS CUSTOMERS METHODS

		public void ListCustomers()
		{
			Console.Clear();

			List<Customer> listCustomers = inventoryLogic.ListCustomers().ToList();

			Console.WriteLine("Customers in the database: \n");

			foreach (var item in listCustomers)
			{
				Console.WriteLine($"Customer name: {item.FirstName} {item.LastName}");
				Console.WriteLine($"Customer id: {item.CustomerId}");
				Console.WriteLine($"Telefono: {item.Telephone} - Email: {item.Email}");
				Console.WriteLine();
			}

			//Console.WriteLine("press any key...");

		}

		public void DisplayMessageToEditCustomer()
		{
			Console.Clear();
			Console.WriteLine(">>> Edit customer's information: ");
			Console.WriteLine();
		}

		public Customer CreateNewCustomer()
		{
			string firstName = "";
			string lastName = "";
			string telephone = "";
			string email = "";
			bool activeCustomer = true;

			Console.WriteLine("Please provide the following information:\n");

			firstName = GetCustomerFirstName();
			lastName = GetCustomerLastName();
			telephone = GetCustomerTelephone();
			email = GetCustomerEmail();

			Customer newCustomer = new Customer
			{
				FirstName = firstName,
				LastName = lastName,
				Telephone = telephone,
				Email = email,
				ActiveCustomer = activeCustomer
			};


			return newCustomer;
		}

		private string GetCustomerFirstName()
		{
			Console.Write("Customer first name: ");
			string customerFirstName = Console.ReadLine();
			return customerFirstName;
		}

		private string GetCustomerLastName()
		{
			Console.Write("Customer last name: ");
			string customerLastName = Console.ReadLine();
			return customerLastName;
		}

		private string GetCustomerTelephone()
		{
			Console.Write("Customer telephone: ");
			string telephone = Console.ReadLine();
			return telephone;
		}

		private string GetCustomerEmail()
		{
			Console.Write("Customer email: ");
			string email = Console.ReadLine();
			return email;
		}

		public void DisplayMessageToAddNewCustomer()
		{
			Console.Clear();
			Console.WriteLine(">>> Add new customer to database: ");
			Console.WriteLine();
		}

		public void AddNewCustomer(Customer newCustomer)
		{
			// Add new customer 
			Console.WriteLine();
			Console.WriteLine("Adding new customer to the system...");
			Console.WriteLine();

			inventoryLogic.AddNewCustomer(newCustomer);
			Console.WriteLine(">>> The customer has been successfully added to the inventory");						
		}

		public void EditCustomerInfo(int customerId)
		{
			Customer customer = inventoryLogic.RetrieveCustomerById(customerId);

			// Edit customer's info
			string firstName = "";
			string lastName = "";
			string telephone = "";
			string email = "";
			string temporaryValue = "";
			
			firstName = customer.FirstName;
			lastName =  customer.LastName;
			telephone = customer.Telephone;
			email = customer.Email;

			Console.WriteLine(">>> Edit customer's information. Note: Leave blank to keep current value!");
			Console.WriteLine();

			Console.WriteLine("Current first name: {0}", firstName);
			Console.Write("First name: ");
			temporaryValue = firstName;
			firstName = Console.ReadLine();
			if (firstName == "")
			{
				firstName = temporaryValue;
			}
			Console.WriteLine();
			Console.WriteLine("Current last name: {0}", lastName);
			Console.Write("Enter new value: ");
			temporaryValue = lastName;
			lastName = Console.ReadLine();
			if (lastName == "")
			{
				lastName = temporaryValue;
			}
			Console.WriteLine();
			Console.WriteLine("Current telephone: {0}", telephone);
			Console.Write("Enter new value: ");
			temporaryValue = telephone;
			telephone = Console.ReadLine();
			if (telephone == "")
			{
				telephone = temporaryValue;
			}
			Console.WriteLine();
			Console.WriteLine("Current email: {0}", email);
			Console.Write("Enter new value: ");
			temporaryValue = email;
			email = Console.ReadLine();
			if (email == "")
			{
				email = temporaryValue;
			}
			// Display confirmation message?

			Console.WriteLine();
			//Console.WriteLine("{0} \n {1} \n {2} \n {3} \n {4}", customerId, firstName, lastName, telephone, email);
			inventoryLogic.EditCustomerInfo(customerId, firstName, lastName, telephone, email);

			Console.WriteLine(">>> Customer information successfully updated\n");			
		}

		public void DisplayCustomers()
		{
			// Display all customers for user to choose one to edit

			List<Customer> listCustomers = inventoryLogic.ListCustomers().ToList();

			//Console.WriteLine("CUSTOMER ID\tFIRST NAME\t\tLAST NAME\t\tTELEPHONE\tEMAIL");

			//foreach (var item in listCustomers)
			//{
			//	Console.WriteLine($"{item.CustomerId}\t\t{item.FirstName}\t\t\t{item.LastName}\t\t\t{item.Telephone}\t{item.Email}");
			//}

			string line = "";
			string header = "CUSTOMER ID".PadRight(12) + "FIRST NAME".PadRight(22) + "LAST NAME".PadRight(22) + "TELEPHONE".PadRight(17) + "EMAIL".PadRight(20);

			Console.WriteLine(header);

			foreach (var item in listCustomers)
			{
				line += item.CustomerId.ToString().PadRight(12);
				line += item.FirstName.PadRight(22);
				line += item.LastName.PadRight(22);
				line += item.Telephone.ToString().PadRight(17);
				line += item.Email.ToString().PadRight(20);
				Console.WriteLine(line);
				line = "";
			}
		}

		public int DisplayMessageToChooseCustomer()
		{
			int customerId = 0;
			bool convertedToInteger = false;
			bool validCustomerId = false;

			do
			{
				Console.WriteLine();
				Console.Write(">>> Please choose a customer id from the list: ");
				convertedToInteger = Int32.TryParse(Console.ReadLine(), out customerId);

				if (convertedToInteger)
				{
					validCustomerId = VerifyIfCustomerIdIsValid(customerId);

					if (!validCustomerId)
					{
						Console.WriteLine(">>> Invalid customer id. Please try again:\n");
					}
				}
				else
				{
					Console.WriteLine(">>> Incorrect value. Please try again:\n");
				}
			} while (!convertedToInteger || !validCustomerId);

			return customerId;
		}

		public bool VerifyIfCustomerIdIsValid(int customerId)
		{
			bool validCustomerId = true;

			// To do, verificar si el customer id esta dentro del rango
			if (!validCustomerId)
			{
				DisplayMessageInvalidCustomerId();
			}

			return validCustomerId;
		}

		public void DisplayMessageInvalidCustomerId()
		{
			Console.WriteLine("\nThe customer id you entered does not exist in our records.");
		}

		public void DisplayMessageToDeleteCustomer()
		{
			Console.Clear();
			Console.WriteLine(">>> Deleting a customer: ");
			Console.WriteLine();
		}

		public void RemoveCustomerById(int customerId)
		{
			Console.WriteLine(">>> Removing customer by id...\n");
			inventoryLogic.RemoveCustomerById(customerId);
			Console.WriteLine(">>> Customer successfully removed from database");
		}




		// END OF ADMIN METHODS

		// BEGINNING OF USER METHODS

		public void DisplayMessageToCreateNewInvoice()
		{
			Console.Clear();
			Console.WriteLine(">>> Create a new invoice. List of customers: ");
			Console.WriteLine();
		}

		public Invoice CreateNewInvoice(int customerId)
		{
			Invoice newInvoice = new Invoice
			{
				CustomerId = customerId,
				PurchaseDate = DateTime.Now
			};
			
			return newInvoice;
		}

		public void AddNewInvoice(Invoice newInvoice)
		{
			// Add new invoice 
			//Console.WriteLine();
			//Console.WriteLine("Creating new invoice... ");
			

			inventoryLogic.AddNewInvoice(newInvoice);
			//Console.WriteLine(">>> Invoice successfully created");
			Console.WriteLine();
			Console.WriteLine(">>> Press any key to choose the products you want to add to the invoice: ");
			Console.ReadKey();
		}

		public void DisplayMessageToChooseProducts()
		{
			Console.WriteLine();
			Console.Write(">>> Please choose the products you want to add to the invoice: ");			
			//Console.Clear();
		}

		public void AddProductsToInvoice()
		{
			Invoice lastInvoice = inventoryLogic.GetLastInvoiceInserted();

			int invoiceId = lastInvoice.InvoiceId;
			int productId = 0;
			int quantity = 0;

			bool addMoreProducts = false;
			string userInput = "";

			List<ProdXInvoice> listOfProdXInvoices = new List<ProdXInvoice>();

			Console.WriteLine();
			Console.WriteLine(">>> Add products to the new invoice....");
			Console.WriteLine();

			DisplayMessageToListProductsInInventory();
			ListInventoryItems();

			do
			{				
				productId = DisplayMessageToChooseProduct();
				quantity = GetProductQuantity();

				ProdXInvoice newProdXInvoice = new ProdXInvoice
				{
					InvoiceId = invoiceId,
					ProductId = productId,
					Quantity = quantity,
				};

				listOfProdXInvoices.Add(newProdXInvoice);

				Console.WriteLine();
				Console.Write(">>> Do you want to add more products to the invoice? [y] > Yes | [n] > No: ");
				userInput = Console.ReadLine();
				
				if (userInput.Equals("no") || userInput.Equals("n"))
				{
					addMoreProducts = false;
				}
				else
				{
					addMoreProducts = true;
				}

			} while (addMoreProducts);
			
			inventoryLogic.AddProductsToInvoice(listOfProdXInvoices);

			Console.WriteLine();
			Console.WriteLine(">>> Products successfully added to invoice");
		}

		public void DisplayMessageToGenerateInvoicesReportByDates()
		{
			Console.Clear();
			Console.WriteLine(">>> Invoice report by dates. Please provide the following data: ");
			Console.WriteLine();
		}

		public void DisplayMessageToGenerateInvoicesReportByCustomerId()
		{
			Console.Clear();
			Console.WriteLine(">>> Invoice report by customer id. List of customers: ");
			Console.WriteLine();
		}

		public string RequestDate(string message)
		{
			string date = "";
			Console.Write(message + "Format must be dd/MM/yyyy: ");				
			date = Console.ReadLine();
			Console.WriteLine();
			
			return date;
		}

		public bool ValidateDate(string date)
		{
			bool validatesAgainstRegex = false;
			bool isValidDate = false;
			
			Regex regex = new Regex(@"^(((((0[1-9])|(1\d)|(2[0-8]))\/((0[1-9])|(1[0-2])))|((31\/((0[13578])|(1[02])))|((29|30)\/((0[1,3-9])|(1[0-2])))))\/((20[0-9][0-9])|(19[0-9][0-9])))|((29\/02\/(19|20)(([02468][048])|([13579][26]))))$");
			validatesAgainstRegex = regex.IsMatch(date);

			if (date != "")
			{
				if (validatesAgainstRegex)
				{
					isValidDate = true;
				}
			}
			
			return isValidDate;
		}

		public void GenerateInvoiceReportFromDatesRange(string startD, string endD, bool validStartDate, bool validEndDate)
		{
			List<Invoice> invoicesList;

			if (validStartDate && validEndDate)
			{
				DateTime startDate = DateTime.ParseExact(startD, "dd/MM/yyyy", CultureInfo.InvariantCulture);
				DateTime endDate = DateTime.ParseExact(endD, "dd/MM/yyyy", CultureInfo.InvariantCulture);

				invoicesList = inventoryLogic.GetInvoicesWithinDateRange(startDate, endDate).ToList();
								
				Console.WriteLine(">>> Invoices report from {0} to {1} \n", startDate.ToString("dd MMM, yyyy"), endDate.ToString("dd MMM, yyyy"));
			}
			else
			{
				Console.WriteLine(">>> Invoices report af all times. Dates provided were invalid:\n");
				invoicesList = inventoryLogic.GetAllInvoices().ToList();
			}
						
			string line = "";
			string header = "INVOICE ID".PadRight(15) + "CUSTOMER ID".PadRight(15) + "PURCHASE DATE".PadRight(22);

			Console.WriteLine(header);

			foreach (var item in invoicesList)
			{
				line += item.InvoiceId.ToString().PadRight(15);
				line += item.CustomerId.ToString().PadRight(15);
				line += item.PurchaseDate.ToString().PadRight(22);
				Console.WriteLine(line);
				line = "";
			}
		}

		public void GenerateInvoiceReportByCustomerId(int customerId)
		{
			Console.WriteLine();

			List<Invoice> listInvoicesByCustomerId = inventoryLogic.GetInvoicesByCustomerId(customerId).ToList();

			Console.WriteLine(">>> Invoices report for customer id {0} \n", customerId);

			string line = "";
			string header = "INVOICE ID".PadRight(15) + "CUSTOMER ID".PadRight(15) + "PURCHASE DATE".PadRight(22);

			Console.WriteLine(header);

			foreach (var item in listInvoicesByCustomerId)
			{
				line += item.InvoiceId.ToString().PadRight(15);
				line += item.CustomerId.ToString().PadRight(15);
				line += item.PurchaseDate.ToString().PadRight(22);
				Console.WriteLine(line);
				line = "";
			}

			decimal total = inventoryLogic.GetInvoicesGrandTotalByCustomerId(customerId);
			List<TopThreeProd> listTopThreePurchasedProducts = inventoryLogic.GetTopThreePurchasedProducts(customerId).ToList();
			decimal average = inventoryLogic.GetAverageSpentOnInvoice(customerId);

			Console.WriteLine();
			Console.WriteLine($">>> Grand total: {String.Format("{0:C}", total)}");
			Console.WriteLine($">>> Average spent on purchases: {String.Format("{0:C}", average)}\n");
 
			header = "PRODUCT ID".PadRight(15) + "PRODUCT".PadRight(22) + "QUANTITY".PadRight(15) + "CATEGORY".PadRight(15);

			Console.WriteLine(header);
			foreach (var item in listTopThreePurchasedProducts)
			{
				line += item.ProductId.ToString().PadRight(15);
				line += item.ProductName.PadRight(22);
				line += item.Total_Quantity.ToString().PadRight(15);
				line += item.Name.PadRight(15);
				Console.WriteLine(line);
				line = "";
			}
		}
	}
}
