using System;
using System.IO;

namespace InventoryApp.FileHandler.Invoices
{
    public static class NewInvoice
    {
        static string path = @AppDomain.CurrentDomain.BaseDirectory + "InventoryFile.csv";
        static string invoicesPath = AppDomain.CurrentDomain.BaseDirectory + "Invoices/";
        //static string newLines = "";
        static string invoiceData = "";
        static decimal total = 0;

        public static bool CreateNewInvoice()
        {
            string[] lines = File.ReadAllLines(path);
            bool productExists = false;
            string productId = "";
            bool addMore = false;
            bool invoiceCreated = true;

            // verifico si el archivo existe
            if (File.Exists(path))
            {              
                Console.WriteLine("**** ADD ITEMS TO INVOICE ***\n");

                if (lines.Length > 0)
                {
                    Console.WriteLine("Please provide the following data: \n"); // va fuera del 'do-while?
                    do
                    {   //ask for product id 
                        productId = ReadProductId();
                        productExists = VerifyIfProductExists(productId, ref lines); //verify if product exists

                        if (productExists)
                        {
                            UpdateProductQuantity(lines, productId);  
                        } else
                        {
                            Console.Clear();
                            Console.WriteLine(">>> The product ID entered does not exists. Check inventory file and try again:\n");
                            invoiceCreated = false;
                            break;
                        }

                        addMore = AddMore();

                    } while (addMore);

                }
                else
                {
                    invoiceCreated = false;
                    Console.WriteLine("No items in inventory file.\n");
                }
            }
            else
            {
                invoiceCreated = false;
                Console.WriteLine("Inventory file does not exist.\nTo create a new file choose option 1 from the menu.");
            }
            return invoiceCreated;
        }

        private static void UpdateProductQuantity(string[] lines, string productId)
        {
            string line = "";
            string[] lineDetails;
            int currentQuantity = 0;
            decimal currentCost = 0;
            int quantity = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                line = lines[i];
                lineDetails = line.Split(',');
                //newLines += line + Environment.NewLine;
                if (lineDetails[0] == productId)
                {
                    currentQuantity = Int32.Parse(lineDetails[3]);
                    currentCost = Decimal.Parse(lineDetails[2]);
                    Console.WriteLine(">>> Number of supplies: {0}", currentQuantity);

                    quantity = GetProductQuantity(currentQuantity);

                    currentQuantity -= quantity;
                    //Console.WriteLine("Test quantity: " + currentQuantity);

                    lines[i] = productId + "," + lineDetails[1] + "," + lineDetails[2] + "," + currentQuantity.ToString();

                    AddDataToInvoice(productId, lineDetails[1], lineDetails[2], quantity, currentCost);

                    break;
                }
            }
            File.WriteAllLines(path, lines);
        }

        private static int GetProductQuantity(int currentQuantity)
        {
            int quantity = 0;

            do
            {
                quantity = RequestProductQuantity();

                if (quantity > currentQuantity)
                {
                    Console.WriteLine("\nThere are not enough supplies to fulfill your request! Try again:\n");
                }
            } while (quantity > currentQuantity);

            return quantity;
        }

        private static void AddDataToInvoice(string productId, string name, string cost, int quantity, decimal currentCost)
        {
            decimal subtotal = 0;

            subtotal = currentCost * quantity;
            invoiceData += productId + "," + name + "," + cost + "," + quantity.ToString() + "," + subtotal.ToString() + Environment.NewLine;
            total += subtotal;
        }

        private static bool AddMore()
        {
            bool addMore = false;
            string option = "";

            Console.WriteLine("\nDo you want to add more items to the invoice?");
            Console.Write("Type \'yes\' [y] or \'no\' [n]: ");
            option = Console.ReadLine();
            Console.WriteLine();

            if (option.ToLower() == "yes" || option.ToLower() == "y")
            {
                addMore = true;
            }
            return addMore;
        }




        private static int RequestProductQuantity()
        {
            int product_quantity = 0;
            bool convertedToInt = false;

            do
            {
                Console.Write(">> Enter desired quantity: ");
                string quantity_Value = Console.ReadLine();
                convertedToInt = Int32.TryParse(quantity_Value, out product_quantity);
                if (!convertedToInt)
                {
                    Console.WriteLine("\nIncorrect value. Please try again! \n>>>Quantity values can only be positive or negative integers");
                }
            } while (!convertedToInt);
            return product_quantity;
        }

        private static string ReadProductId()
        {
            Console.Write(">> Product ID: ");
            return Console.ReadLine();
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

        public static void AddItemToInvoice(int counter)
        {
            //string invoicesPath = AppDomain.CurrentDomain.BaseDirectory + "Invoices/";
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
            Console.WriteLine(">>> Invoice created.\n");
        }

        public static int GetNumberOfInvoice(){
            int filesCounter = Directory.GetFiles(invoicesPath).Length - 1;
            //Console.WriteLine("filesCounter: " + filesCounter);
            //Console.WriteLine("++filesCounter: " + ++filesCounter);
            //Console.ReadLine();
            return ++filesCounter;
        }
    }
}
