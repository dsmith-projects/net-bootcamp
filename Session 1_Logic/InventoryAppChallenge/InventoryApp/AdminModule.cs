using System;
using InventoryApp.FileHandler;

namespace InventoryApp
{
    public class AdminModule
    {
        string input;
        int option;
        int exitValue;

        public AdminModule()
        {
            this.input = "";
            this.option = 0;
            this.exitValue = 5;
        }

        public void DisplayAdminMenu()
        {
            Console.WriteLine("**** MAIN MENU ****");
            Console.WriteLine();
            Console.WriteLine("1. LIST inventory items");
            Console.WriteLine("2. ADD a new item to the inventory");
            Console.WriteLine("3. MODIFY the number of item supplies");
            Console.WriteLine("4. REMOVE an item from the inventory");
            Console.WriteLine("5. EXIT application");
        }

        public void RunAdminModule()
        {
            Console.Clear();
            Console.WriteLine(">>> You have been authenticated. Welcome ADMIN user!\n");

            while (option != exitValue)
            {
                DisplayAdminMenu();

                Console.Write("\nChoose an option: ");
                input = Console.ReadLine();
                bool result = Int32.TryParse(input, out option);

                if (result)
                {
                    switch (option)
                    {
                        case 1:
                            Console.Clear();
                            ReadWriteFiles.ListInventory();
                            break;
                        case 2:
                            Console.Clear();
                            NewItem newItem = new NewItem();
                            newItem.GetItemData();
                            break;
                        case 3:
                            Console.Clear();
                            ReadWriteFiles.ModifyItemData();
                            break;
                        case 4:
                            Console.Clear();
                            ReadWriteFiles.RemoveItemFromInventory();
                            break;
                        case 5:
                            Console.Clear();
                            Console.WriteLine("EXITING the application... Thank you!");
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine(">>> Invalid number. Please try again!\n");
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
