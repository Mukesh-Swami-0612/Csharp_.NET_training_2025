using System;

class Program
{
    static void Main()
    {
        Predicate<int> isEven = num => num % 2 == 0;

        Console.WriteLine(isEven(10)); // True
        Console.WriteLine(isEven(7));  // False
    }
}
