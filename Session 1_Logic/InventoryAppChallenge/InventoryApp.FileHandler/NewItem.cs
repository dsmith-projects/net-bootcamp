using System;
using System.IO;

namespace InventoryApp.FileHandler
{
    public class NewItem
    {

        string inventoryFilePath;
        string productId;
        string productName;
        decimal cost;
        int quantity;

        public NewItem()
        {

            this.inventoryFilePath = AppDomain.CurrentDomain.BaseDirectory + "InventoryFile.csv";
            this.productId = "";
            this.productName = "";
            this.cost = 0;
            this.quantity = 0;
        }

        public void GetItemData()
        {
            Console.WriteLine("**** NEW ITEM ****");
            Console.WriteLine();
            Console.WriteLine("Provide data for the new item: ");
            Console.WriteLine();
            productId = ReadProductId();
            productName = ReadProductName();
            cost = RequestProductCost();
            quantity = RequestProductQuantity();

            AddItemToInventory(productId, productName, cost, quantity);

            Console.Clear();
            Console.WriteLine(">>> Product item SUCCESSFULLY added to the inventory\n");
        }

        public string ReadProductId()
        {
            Console.Write(">> Product ID: ");
            return Console.ReadLine();
        }

        public string ReadProductName()
        {
            Console.Write(">> Name: ");
            return Console.ReadLine();
        }

        public static int RequestProductQuantity()
        {
            int quantity = 0;
            bool converted = false;

            do
            {
                Console.Write(">> Available Quantity: ");
                string quantityValue = Console.ReadLine();
                converted = Int32.TryParse(quantityValue, out quantity);
                if (!converted)
                {
                    Console.WriteLine("\nIncorrect value. Please try again! \n>>>Quantity values can only be positive or negative integers");
                }
            } while (!converted);
            return quantity;
        }

        public static decimal RequestProductCost()
        {
            decimal cost = 0;
            bool converted = false;

            do
            {
                Console.Write(">> Cost: ");
                string costValue = Console.ReadLine();
                converted = Decimal.TryParse(costValue, out cost);
                if (!converted)
                {
                    Console.WriteLine("\nIncorrect value. Please try again! ");
                }
            } while (!converted);
            return cost;
        }

        public void AddItemToInventory(string productId, string productName, decimal cost, int quantity)
        {
            string newLine = "";
            newLine += productId + "," + productName + "," + cost + "," + quantity;
            File.AppendAllText(inventoryFilePath, newLine.ToString());
        }

    }
}
