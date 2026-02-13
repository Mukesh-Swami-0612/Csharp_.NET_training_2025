using System;

class Program
{
    static void Main()
    {
        string s = "HeLLo";

        int lower = 0;
        string result = "";

        foreach (char c in s)
        {
            if (char.IsLower(c))
            {
                lower++;
                result += char.ToUpper(c);
            }
            else
                result += c;
        }

        Console.WriteLine("Lowercase Count: " + lower);
        Console.WriteLine("Converted: " + result);
    }
}
