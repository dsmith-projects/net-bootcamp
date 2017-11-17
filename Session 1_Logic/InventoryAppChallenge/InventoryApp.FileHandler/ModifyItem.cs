using System;
using System.IO;

namespace InventoryApp.FileHandler
{
    public static class ModifyItem
    {
        static string path = @AppDomain.CurrentDomain.BaseDirectory + "InventoryFile.csv";
        static string productId = "";
        static int quantity = 0;
        static bool productFound = false;

        public static void ModifyItemData()
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("Inventory file does not exist.\nTo create a new file choose option 1 from the menu.");
            }
            else
            {
                try
                {
                    string[] lines = File.ReadAllLines(path);

                    if (lines.Length > 0)
                    {
                        Console.WriteLine("**** MODIFY ITEM QUANTITY ***\n");
                        Console.WriteLine("Please provide the following data: \n");

                        productId = ReadProductId();
                        productFound = ReplaceLine(lines, productId);

                        if (productFound)
                        {
                            File.WriteAllLines(path, lines);
                            Console.Clear();
                            Console.WriteLine(">>> Product quantity SUCCESSFULLY updated.\n");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine(">>> The product id you provided did not match any products in the inventory.\n");
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("The file could not be read. Please try again.");
                }
            }
        }

        private static bool ReplaceLine(string[] lines, string product_Id)
        {
            string line = "";
            string[] lineDetails;
            string newLine = "";
            bool product_Found = false;

            for (int i = 0; i < lines.Length; i++)
            {
                line = lines[i];
                lineDetails = line.Split(',');

                if (lineDetails[0] == product_Id)
                {
                    quantity += RequestProductQuantity() + Int32.Parse(lineDetails[3]);
                    newLine = product_Id + "," + lineDetails[1] + "," + lineDetails[2] + "," + quantity.ToString();
                    lines[i] = newLine;

                    product_Found = true;
                    break;
                }
            }
            return product_Found;
        }

        private static int RequestProductQuantity()
        {
            int product_quantity = 0;
            bool converted = false;
            string quantityValue = "";

            do
            {
                Console.Write(">> Available Quantity: ");
                quantityValue = Console.ReadLine();
                converted = Int32.TryParse(quantityValue, out product_quantity);
                if (!converted)
                {
                    Console.WriteLine("\nIncorrect value. Please try again! \n>>>Quantity values can only be positive or negative integers");
                }
            } while (!converted);
            return product_quantity;
        }

        public static string ReadProductId()
        {
            Console.Write(">> Product ID: ");
            return Console.ReadLine();
        }
    }
}
