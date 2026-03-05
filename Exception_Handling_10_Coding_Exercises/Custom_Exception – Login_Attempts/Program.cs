
using System;

class LoginFailedException : Exception
{
    public LoginFailedException(string message) : base(message)
    {
    }
}

class LoginSystem
{
    static void Main()
    {
        int attempts = 0;
        string correctUser = "mukesh";
        string correctPass = "1234";

        while (attempts < 3)
        {
            try
            {
                Console.Write("Enter Username: ");
                string user = Console.ReadLine();

                Console.Write("Enter Password: ");
                string pass = Console.ReadLine();

                if (user == correctUser && pass == correctPass)
                {
                    Console.WriteLine("Login Successful.");
                    return;
                }
                else
                {
                    attempts++;
                    Console.WriteLine("Invalid Credentials. Attempts Left: " + (3 - attempts));
                }

                if (attempts == 3)
                {
                    throw new LoginFailedException("Too many failed login,Access blocked.");
                }
            }
            catch (LoginFailedException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Environment.Exit(0);
            }
        }
    }
}
