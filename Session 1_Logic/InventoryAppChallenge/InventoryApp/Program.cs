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
					//Console.WriteLine("Run app as admin");
                    bool authenticated = AuthenticateAdminUser();
                    Console.WriteLine("authenticated: {0}", authenticated);
                    if (authenticated)
                    {
                        RunAdminModule();
                    } else
                    {
                        Console.WriteLine("Access denied. Try again or contact your system administrator");
                    }
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

            do
            {
                Console.Write("Please enter your username: ");
                username = Console.ReadLine();
                Console.Write("Please enter your password: ");
                password = Console.ReadLine();

                numAttempt++;
                //Console.WriteLine("Username: {0} - Password: {1}", username, password);
                //Console.WriteLine("DefaultUsername: {0} - DefaultPassword: {1}", DefaultUsername, DefaultPassword);
                if (username.Equals(DefaultUsername) && password.Equals(DefaultPassword))
                {
                    userVerified = true;
                    authenticated = true;
                }
                else if(numAttempt < 3)
                {
                    Console.WriteLine("Try again! Either the username or the password is incorrect. {0} attemps left", (MaxNumAttempts - numAttempt));
                }

            } while (!userVerified && numAttempt < MaxNumAttempts);

            if(numAttempt >= MaxNumAttempts) {
                Console.WriteLine("Maximum number of attempts reached\nLocking your account. Contact your system administrator >> TODO");
            }

            return authenticated;
        }

        public static void RunAdminModule()
        {
            int option = DisplayMenu();

            switch (option)
            {
                case 1:
                    break;
				case 2:
					break;
				case 3:
					break;
				case 4:
					break;
				case 5:
					break;
                default:
                    break;
            }
        }

        public static int DisplayMenu() {
            
        }

    }
}
