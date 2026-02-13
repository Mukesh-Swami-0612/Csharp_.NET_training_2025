using System;

class Program
{
    static void Main()
    {
        char[] arr = { 'A', 'B', 'C' };

        string result = "";

        foreach (char c in arr)
        {
            result += c.ToString() + ",";
        }

        Console.WriteLine(result.TrimEnd(','));
    }
}
