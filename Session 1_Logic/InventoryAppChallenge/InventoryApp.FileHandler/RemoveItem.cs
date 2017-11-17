using System;
using System.IO;

namespace InventoryApp.FileHandler
{
    public static class RemoveItem
    {
        static string path = @AppDomain.CurrentDomain.BaseDirectory + "InventoryFile.csv";
        static string productId = "";
        static bool productFound = false;

        public static void RemoveItemFromInventory()
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
                    string newLines = "";

                    if (lines.Length > 0)
                    {
                        Console.WriteLine("**** DELETE ITEM ***\n");
                        Console.WriteLine("Please provide the following data: \n");

                        productId = ReadProductId();
                        productFound = RemoveProduct(lines, productId, ref newLines);

                        if (productFound)
                        {
                            File.WriteAllText(path, newLines);
                            Console.Clear();
                            Console.WriteLine(">>> Product SUCCESSFULLY deleted.\n");
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

        private static bool RemoveProduct(string[] lines, string product_Id, ref string newLines)
        {
            bool product_Found = false;

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] lineDetails = line.Split(',');

                if (lineDetails[0] != productId)
                {
                    newLines += line + Environment.NewLine;
                }
                else
                {
                    product_Found = true;
                }
            }
            return product_Found;
        }

        public static string ReadProductId()
        {
            Console.Write(">> Product ID: ");
            return Console.ReadLine();
        }
    }
}
