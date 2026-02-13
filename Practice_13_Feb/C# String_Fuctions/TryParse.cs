using System;

class Program
{
    static void Main()
    {
        char input = '5';

        bool ok = int.TryParse(input.ToString(), out int n);

        Console.WriteLine(ok ? n.ToString() : "Invalid");
    }
}
