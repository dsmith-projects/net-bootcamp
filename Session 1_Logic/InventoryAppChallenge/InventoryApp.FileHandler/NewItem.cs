using System;
using System.IO;

namespace InventoryApp.FileHandler
{
    public static class NewItem
    {

        static string inventoryFilePath = AppDomain.CurrentDomain.BaseDirectory + "InventoryFile.csv";
        static string productId = "";
        static string productName = "";
        static decimal cost = 0;
        static int quantity = 0;

        public static void GetItemData()
        {
            string[] lines = File.ReadAllLines(inventoryFilePath);
            bool productExists = false;

            Console.WriteLine("**** NEW ITEM ****");
            Console.WriteLine();
            Console.WriteLine("Provide data for the new item: ");
            Console.WriteLine();

            do
            {
                productId = ReadProductId();
                productExists = VerifyIfProductExists(productId, ref lines);

                if (productExists)
                {
                    Console.Clear();
                    Console.WriteLine(">>> The product ID entered already exists. Please enter a different id:\n");
                }

            } while (productExists);


            productName = ReadProductName();
            cost = RequestProductCost();
            quantity = RequestProductQuantity();

            AddItemToInventory(productId, productName, cost, quantity);

            Console.Clear();
            Console.WriteLine(">>> Product item SUCCESSFULLY added to the inventory\n");           
        }

        private static bool VerifyIfProductExists(string product_Id, ref string[] lines)
        {
            bool productExists = false;
            string line = "";
            string[] lineDetails;

            if (lines.Length > 0)
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    line = lines[i];
                    lineDetails = line.Split(',');

                    if (lineDetails[0] == product_Id)
                    {
                        productExists = true;
                        break;
                    }
                }
            }
            return productExists;
        }

        public static string ReadProductId()
        {
            Console.Write(">> Product ID: ");
            return Console.ReadLine();
        }

        public static string ReadProductName()
        {
            Console.Write(">> Name: ");
            return Console.ReadLine();
        }

        public static int RequestProductQuantity()
        {
            int product_quantity = 0;
            bool converted = false;

            do
            {
                Console.Write(">> Available Quantity: ");
                string quantityValue = Console.ReadLine();
                converted = Int32.TryParse(quantityValue, out product_quantity);
                if (!converted)
                {
                    Console.WriteLine("\nIncorrect value. Please try again! \n>>>Quantity values can only be positive or negative integers");
                }
            } while (!converted);
            return product_quantity;
        }

        public static decimal RequestProductCost()
        {
            decimal product_cost = 0;
            bool converted = false;

            do
            {
                Console.Write(">> Cost: ");
                string costValue = Console.ReadLine();
                converted = Decimal.TryParse(costValue, out product_cost);
                if (!converted)
                {
                    Console.WriteLine("\nIncorrect value. Please try again! ");
                }
            } while (!converted);
            return product_cost;
        }

        public static void AddItemToInventory(string productId, string productName, decimal cost, int quantity)
        {
            string newLine = "";
            newLine += productId + "," + productName + "," + cost + "," + quantity + Environment.NewLine;
            File.AppendAllText(inventoryFilePath, newLine.ToString());
        }

    }
}
