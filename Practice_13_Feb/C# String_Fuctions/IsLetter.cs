using System;

class Program
{
    static void Main()
    {
        string password = "AbcD12EfG!";
        string text = "Hello@World#123";

        int letterCount = 0;
        string cleaned = "";

        foreach (char c in password)
        {
            if (char.IsLetter(c))
                letterCount++;
        }

        foreach (char c in text)
        {
            if (char.IsLetter(c) || c == ' ')
                cleaned += c;
        }

        Console.WriteLine("Valid Password: " + (letterCount >= 5));
        Console.WriteLine("Cleaned Text: " + cleaned);
    }
}
