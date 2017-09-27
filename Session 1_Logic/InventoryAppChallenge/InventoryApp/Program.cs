using System;

namespace InventoryApp
{
    class MainClass
    {
        public static void Main(string[] args)
        {
			Console.WriteLine("Number of command line parameters = {0}", args.Length);

            if (args.Length == 1)
			{
				if (args[0].ToLower() == "admin")
				{
					Console.WriteLine("Run app as admin");
                    bool authenticated = AuthenticateAdminUser();
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

        public static bool AuthenticateAdminUser() 
        {
            string username = "";
            string password = "";
			const string DefaultUsername = "hola";
			const string DefaultPassword = "mundo";

            const int MaxNumAttempts = 3;
            int numAttempt = 0;
            bool userVerified = false;
            bool authenticated = false;

            while (!userVerified || numAttempt < MaxNumAttempts)
            {
                Console.Write("Please enter your username: ");
                username = Console.ReadLine();
                Console.Write("Please enter your password: ");
                password = Console.ReadLine();

                numAttempt++;

                if (username.Equals(DefaultUsername) && password.Equals(DefaultPassword))
                {
                    userVerified = true;
                    authenticated = true;
                } 
                else
                {
                    Console.WriteLine("Try again! Either the username or the password is incorrect. {0} attemps left", (MaxNumAttempts - numAttempt));
                }

            }

            if(numAttempt >= MaxNumAttempts) {
                Console.WriteLine("Locking the account >> TODO");
            }

            return authenticated;

        }
    }
}
