using System;
using System.Configuration;

namespace InventoryApp
{
    public class AuthenticateAdmin
    {

        const int MaxNumAttempts = 3;
        int numAttempt;
        bool userVerified;
        bool authenticated;

        public string Username { get; set; }
        public string Password { get; set; }

        public string DefaultUsername { get; set; }
        public string DefaultPassword { get; set; }

        public AuthenticateAdmin()
        {
            this.numAttempt = 0;

            this.userVerified = false;
            this.authenticated = false;

            this.Username = "";
            this.Password = "";

            this.DefaultUsername = ConfigurationManager.AppSettings.Get("username");
            this.DefaultPassword = ConfigurationManager.AppSettings.Get("password");
        }

        public bool AuthenticateAdminUser()
        {
            do
            {
                Console.Write("Please enter your username: ");
                Username = Console.ReadLine();
                Console.Write("Please enter your password: ");
                Password = Console.ReadLine();

                numAttempt++;

                if (Username.Equals(DefaultUsername) && Password.Equals(DefaultPassword))
                {
                    userVerified = true;
                    authenticated = true;
                }
                else
                {
                    if (numAttempt < 3)
                    {
                        Console.WriteLine("\n>>> Try again! Either username or password is incorrect. {0} attemps left", (MaxNumAttempts - numAttempt));
                    }
                }

                Console.WriteLine();
            } while (!userVerified && numAttempt < MaxNumAttempts);

            return authenticated;
        }

    }
}
