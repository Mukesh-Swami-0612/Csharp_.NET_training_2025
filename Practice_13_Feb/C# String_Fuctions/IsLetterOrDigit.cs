using System;

class Program
{
    static void Main()
    {
        string input = "User@123#";
        string username = "User1234";

        string cleaned = "";

        foreach (char c in input)
        {
            if (char.IsLetterOrDigit(c))
                cleaned += c;
        }

        bool valid = true;

        if (username.Length < 8)
            valid = false;

        foreach (char c in username)
        {
            if (!char.IsLetterOrDigit(c))
                valid = false;
        }

        Console.WriteLine("Cleaned: " + cleaned);
        Console.WriteLine("Valid Username: " + valid);
    }
}
