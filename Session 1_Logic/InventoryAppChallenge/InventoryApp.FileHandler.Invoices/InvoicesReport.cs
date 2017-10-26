using System;
using System.IO;

namespace InventoryApp.FileHandler.Invoices
{
    public static class InvoicesReport
    {
        static string invoicesPath = AppDomain.CurrentDomain.BaseDirectory + "Invoices/";

        public static void DisplayInvoicesReport()
        {
            string[] fileNames = Directory.GetFiles(invoicesPath);
            string fileName = "";
            string line = "";
            string[] lineDetails;
            string[] lines;
            decimal total = 0;
            decimal grandTotal = 0;
            int invoicesCounter = Directory.GetFiles(invoicesPath).Length - 1;

            for (int i = 1; i < fileNames.Length; i++)
            {
                fileName = fileNames[i];
                lines = File.ReadAllLines(fileName);
                line = lines[lines.Length - 1];
                lineDetails = line.Split(',');
                total = Decimal.Parse(lineDetails[4]);
                Console.WriteLine("total: " + total);
                grandTotal += total;
            }
            //Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Number of invoices created: {0}", invoicesCounter);
            Console.WriteLine("Grand total for all invoices: {0}", grandTotal);
            Console.WriteLine("\nPress any key to continue");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
