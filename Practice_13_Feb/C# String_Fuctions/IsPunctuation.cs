using System;

class Program
{
    static void Main()
    {
        string s = "Hello, World! How are you?";

        int count = 0;
        string cleaned = "";

        foreach (char c in s)
        {
            if (char.IsPunctuation(c))
                count++;
            else
                cleaned += c;
        }

        Console.WriteLine("Punctuation Count: " + count);
        Console.WriteLine("Cleaned: " + cleaned);
    }
}
