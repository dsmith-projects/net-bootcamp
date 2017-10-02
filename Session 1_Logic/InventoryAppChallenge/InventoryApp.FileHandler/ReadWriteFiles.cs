using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.FileHandler
{
    public static class ReadWriteFiles
    {
        public static void ListInventory()
        {
            string path = @AppDomain.CurrentDomain.BaseDirectory + "InventoryFile.csv";

            if (!File.Exists(path))
            {
                Console.WriteLine("Inventory file does not exist.\nCreating a new empty inventory file.\nHit enter to continue.");
                string[] fileHeader = { "PROD_ID,NAME,COST,QUANTITY" };
                File.WriteAllLines(path, fileHeader);
            }
            else
            {
                try
                {
                    string[] lines = File.ReadAllLines(path);

                    if (lines.Length > 0)
                    {
                        Console.WriteLine("**** INVENTORY ****\n");
                        foreach (string line in lines)
                        {
                            string[] lineDetails = line.Split(',');
                            foreach (var item in lineDetails)
                            {
                                Console.Write(item + "\t\t");
                            }
                            Console.WriteLine();
                        }
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

        public static void AddItemToInventory()
        {
            string inventoryFilePath = AppDomain.CurrentDomain.BaseDirectory + "InventoryFile.csv";

            string productId = "";
            string productName = "";
            decimal cost = 0;
            int quantity = 0;

            Console.WriteLine("**** NEW ITEM ****");
            Console.WriteLine();
            Console.WriteLine("Provide data for the new item: ");
            Console.WriteLine();
            Console.Write(">> Product ID: ");
            productId = Console.ReadLine();
            Console.Write(">> Name: ");
            productName = Console.ReadLine();
            cost = RequestProductCost();
            quantity = RequestProductQuantity();

            // I must include a try/catch block for the following section
            StringBuilder newLine = new StringBuilder();
            newLine.AppendLine(productId + "," + productName + "," + cost + "," + quantity);
            File.AppendAllText(inventoryFilePath, newLine.ToString());
            Console.Clear();
            Console.WriteLine(">>> Product item SUCCESSFULLY added to the inventory\n");
        }

        public static void ModifyItemData()
        {
            string productId = "";
            string quantityValue = "";
            int quantity = 0;
            bool converted = false;
            bool productFound = false;

            string path = @AppDomain.CurrentDomain.BaseDirectory + "InventoryFile.csv";

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

        public static void RemoveItemFromInventory()
        {
            string productId = "";
            bool productFound = false;

            string path = @AppDomain.CurrentDomain.BaseDirectory + "InventoryFile.csv";

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
                        Console.Write(">> Product ID: ");
                        productId = Console.ReadLine();

                        for (int i = 0; i < lines.Length; i++)
                        {
                            string line = lines[i];
                            string[] lineDetails = line.Split(',');
                            //Console.WriteLine("lineDetails[0] != productId: {0}", (lineDetails[0] != productId));
                            if (lineDetails[0] != productId)
                            {
                                newLines += line + Environment.NewLine;
                            }
                            else
                            {
                                productFound = true;
                            }
                        }
                        //Console.WriteLine("productFound: " + productFound);
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

        public static decimal CreateNewInvoice(int counter)
        {
            string productId = "";
            string quantityValue = "";
            int quantity = 0;
            int currentQuantity = 0;
            bool converted = false;
            bool productFound = false;
            bool addMore = false;
            string option = "";
            string invoiceData = "";
            decimal total = 0;


            string path = @AppDomain.CurrentDomain.BaseDirectory + "InventoryFile.csv";

            if (!File.Exists(path))
            {
                Console.WriteLine("Inventory file does not exist.\nTo create a new file choose option 1 from the menu.");
            }
            else
            {
                //try
                //{
                string[] lines = File.ReadAllLines(path);
                Console.WriteLine("**** ADD ITEMS TO INVOICE ***\n");

                do
                {
                    addMore = false;

                    if (lines.Length > 0)
                    {
                        Console.WriteLine("Please provide the following data: \n");
                        Console.Write(">> Product ID: ");
                        productId = Console.ReadLine();

                        for (int i = 0; i < lines.Length; i++)
                        {
                            string line = lines[i];
                            string[] lineDetails = line.Split(',');

                            if (lineDetails[0] == productId)
                            {
                                currentQuantity = Int32.Parse(lineDetails[3]);

                                do
                                {
                                    Console.Write(">> Quantity: ");
                                    quantityValue = Console.ReadLine();
                                    converted = Int32.TryParse(quantityValue, out quantity);
                                    if (!converted)
                                    {
                                        Console.WriteLine("\nIncorrect value. Please try again! ");
                                    }
                                    if (quantity > currentQuantity)
                                    {
                                        Console.WriteLine("\nThere are not enough supplies to fulfill your request!\n");
                                    }
                                } while (!converted || (quantity > currentQuantity));

                                currentQuantity -= quantity;

                                lines[i] = productId + "," + lineDetails[1] + "," + lineDetails[2] + "," + currentQuantity.ToString();

                                productFound = true;

                                // add product and quantity to invoice and total
                                invoiceData += productId + "," + lineDetails[1] + "," + lineDetails[2] + "," + quantityValue + "," + ((Decimal.Parse(lineDetails[2]) * quantity).ToString()) + Environment.NewLine;
                                total += Decimal.Parse(lineDetails[2]) * quantity;
                                break;
                            }
                        }

                        if (productFound)
                        {
                            File.WriteAllLines(path, lines);
                            Console.Clear();
                            Console.WriteLine(">>> Product SUCCESSFULLY added to invoice.\n");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine(">>> The product id you provided did not match any products in the inventory.\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No items in inventory file.\n");
                    }

                    do
                    {
                        Console.WriteLine("Do you want to add more items to the invoice?");
                        Console.Write("Type \'yes\' [y] or \'no\' [n]: ");
                        option = Console.ReadLine();
                        Console.WriteLine();
                    } while (option.ToLower() != "yes" && option.ToLower() != "y" && option.ToLower() != "no" && option.ToLower() != "n");

                    if (option.ToLower() == "yes" || option.ToLower() == "y")
                    {
                        addMore = true;
                    }
                    else
                    {
                        AddItemToInvoice(invoiceData, total, counter);
                        Console.Clear();
                    }

                } while (addMore);
            }
            return total;
        }

        public static void AddItemToInvoice(string invoiceData, decimal total, int counter)
        {
            string invoicesPath = AppDomain.CurrentDomain.BaseDirectory + "Invoices/";
            string newInvoicePath = invoicesPath + "Invoice" + counter.ToString() + ".csv";
            string[] fileHeader = { "PROD_ID,NAME,PRICE,QUANTITY,COST" };
            string totalLine = "*TOTAL:*,-----,-----,-----," + total.ToString();

            if (!Directory.Exists(invoicesPath))
            {
                Directory.CreateDirectory(invoicesPath);
            }

            File.WriteAllLines(newInvoicePath, fileHeader);
            File.AppendAllText(newInvoicePath, invoiceData);
            File.AppendAllText(newInvoicePath, totalLine);
            Console.Clear();
            Console.WriteLine(">>> Invoice created");
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
