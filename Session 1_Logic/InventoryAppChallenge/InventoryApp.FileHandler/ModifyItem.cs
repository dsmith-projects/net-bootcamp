using System;
using System.IO;

namespace InventoryApp.FileHandler
{
    public class ModifyItem
    {
        string path;
        string productId;
        string quantityValue;
        int quantity;
        bool converted;
        bool productFound;

        public ModifyItem()
        {
            this.path = @AppDomain.CurrentDomain.BaseDirectory + "InventoryFile.csv";
            this.productId = "";
            this.quantityValue = "";
            this.quantity = 0;
            this.converted = false;
            this.productFound = false;
        }

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
                        Console.Write(">> Product ID: ");
                        productId = Console.ReadLine();

                        for (int i = 0; i < lines.Length; i++)
                        {
                            string line = lines[i];
                            string[] lineDetails = line.Split(',');

                            if (lineDetails[0] == productId)
                            {
                                do
                                {
                                    Console.Write(">> Quantity: ");
                                    quantityValue = Console.ReadLine();
                                    converted = Int32.TryParse(quantityValue, out quantity);
                                    if (!converted)
                                    {
                                        Console.WriteLine("\nIncorrect value. Please try again! ");
                                    }
                                } while (!converted);

                                quantity += Int32.Parse(lineDetails[3]);

                                string newLine = productId + "," + lineDetails[1] + "," + lineDetails[2] + "," + quantity.ToString();
                                lines[i] = newLine;

                                productFound = true;
                                break;
                            }
                        }

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
    }
}
