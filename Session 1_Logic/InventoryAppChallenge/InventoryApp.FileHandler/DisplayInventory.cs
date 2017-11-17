using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.FileHandler
{
    public static class DisplayInventory
    {
        public static void ListInventory()
        {
            string path = @AppDomain.CurrentDomain.BaseDirectory + "InventoryFile.csv";

            if (!File.Exists(path))
            {
                CreateNewInventoryFile(path);
            }
            else
            {
                try
                {
                    string[] lines = File.ReadAllLines(path);

                    if (lines.Length > 0)
                    {
                        Console.WriteLine("**** INVENTORY ****\n");
                        ReadLines(lines);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to display. Empty inventory file.");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("The file could not be read. Please try again.");
                }
            }

            Console.WriteLine("\nHit ENTER to continue\n");
            Console.ReadLine();
            Console.Clear();
        }

        private static void ReadLines(string[] lines)
        {
            foreach (string line in lines)
            {
                PrintLine(line);

            }
        }

        private static void PrintLine(string line)
        {
            string[] lineDetails = line.Split(',');
            foreach (var item in lineDetails)
            {
                Console.Write(item + "\t\t");
            }
            Console.WriteLine();
        }

        private static void CreateNewInventoryFile(string path)
        {
            Console.WriteLine("Inventory file does not exist.\nCreating a new empty inventory file.\nHit enter to continue.");
            string[] fileHeader = { "PROD_ID,NAME,COST,QUANTITY" };
            File.WriteAllLines(path, fileHeader);
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
    }
}
