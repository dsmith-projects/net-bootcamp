using System;

namespace InventoryApp
{
    class MainClass
    {
        public static void Main(string[] args)
        {
			if (args.Length == 1)
			{
				if (args[1].ToLower() == "admin")
				{
					Console.WriteLine("Run app as admin");
				}
				else
				{
					Console.WriteLine("Please try again! Make sure you start the app as a user or as the admin");
				}
			}
			else if (args.Length == 0)
			{
				Console.WriteLine("Run app as user");
			}
			else
			{
				Console.WriteLine("Please try again! Make sure you start the app as a user or as the admin");
			}
        }
    }
}
