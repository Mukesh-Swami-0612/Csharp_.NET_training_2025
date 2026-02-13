using System;

class Program
{
    static void Main()
    {
        string code = "AB#12$";

        string symbols = "";
        bool hasSymbol = false;

        foreach (char c in code)
        {
            if (char.IsSymbol(c))
            {
                symbols += c;
                hasSymbol = true;
            }
        }

        Console.WriteLine("Symbols: " + symbols);
        Console.WriteLine("Has Symbol: " + hasSymbol);
    }
}
