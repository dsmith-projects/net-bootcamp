using System;
using System.IO;

namespace InventoryApp.FileHandler.Invoices
{
    public static class NewInvoice
    {
        static string path = @AppDomain.CurrentDomain.BaseDirectory + "InventoryFile.csv";
        static string productId = "";
        static string quantityValue = "";
        static int quantity = 0;
        static int currentQuantity = 0;
        static bool converted = false;
        static bool productFound = false;
        static bool addMore = false;
        static string option = "";
        static string invoiceData = "";
        static decimal total = 0;

        public static decimal CreateNewInvoice(int counter)
        {           

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
    }
}
