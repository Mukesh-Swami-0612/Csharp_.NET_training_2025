using System;

class Program
{
    static void Main()
    {
        string text = "HELLO World TEST DATA";

        int upper = 0;

        foreach (char c in text)
        {
            if (char.IsUpper(c))
                upper++;
        }

        double percent = (double)upper / text.Length * 100;

        Console.WriteLine("Upper Count: " + upper);
        Console.WriteLine("More than 60% Upper: " + (percent > 60));
    }
}
