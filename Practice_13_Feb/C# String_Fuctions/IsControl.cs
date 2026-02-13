using System;

class Program
{
    static void Main()
    {
        string s = "Hello\u0002World";
        string cleaned = "";

        foreach (char c in s)
        {
            if (!char.IsControl(c))
                cleaned += c;
        }
        Console.WriteLine("Cleaned Log: " + cleaned);
    }
}
