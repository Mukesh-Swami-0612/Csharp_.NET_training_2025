using System;

class Program
{
    static void Main()
    {
        char[] arr = { 'd', 'a', 'c', 'b' };
        Array.Sort(arr);

        Console.WriteLine(new string(arr));
        Console.WriteLine('a'.CompareTo('b') < 0);
    }
}
