using System;
using InventoryApp.FileHandler;
using InventoryApp.FileHandler.Invoices;

namespace InventoryApp
{
    public class UserModule
    {
        string input;
        int option;
        int exitValue;
        int counter;
        decimal grandTotal;

        public UserModule()
        {
            this.input = "";
            this.option = 0;
            this.exitValue = 4;
            this.counter = 1000;
            this.grandTotal = 0;
        }

        public static void DisplayUserMenu()
        {
            Console.WriteLine("**** MAIN MENU ****");
            Console.WriteLine();
            Console.WriteLine("1. LIST inventory items");
            Console.WriteLine("2. CREATE new invoice");
            Console.WriteLine("3. DISPLAY invoices report");
            Console.WriteLine("4. EXIT application");
        }

        public void RunUserModule()
        {
            Console.Clear();

            while (option != exitValue)
            {
                DisplayUserMenu();

                Console.Write("\nChoose an option: ");
                input = Console.ReadLine();
                bool result = Int32.TryParse(input, out option);

                if (result)
                {
                    switch (option)
                    {
                        case 1:
                            Console.Clear();
                            DisplayInventory.ListInventory();
                            break;
                        case 2:
                            //Console.WriteLine("CREATE new invoice\n");
                            Console.Clear();
                            //grandTotal += NewInvoice.CreateNewInvoice(counter++);
                            bool invoiceCreated = NewInvoice.CreateNewInvoice();
                            if (invoiceCreated)
                            {
                                int invoiceCounter = NewInvoice.GetNumberOfInvoice();
                                NewInvoice.AddItemToInvoice(invoiceCounter);
                            }
                            break;
                        case 3:
                            //Console.WriteLine("DISPLAY invoice\n");
                            Console.Clear();
                            InvoicesReport.DisplayInvoicesReport();
                            break;
                        case 4:
                            Console.Clear();
                            Console.WriteLine("EXITING the application... Thank you!");
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine(">>> Invalid input. Please try again!\n");
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine(">>> Invalid input. Please try again!\n");
                }
            }

        }



    }
}
