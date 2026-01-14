using System;
using System.Threading;

public class ThreadEvenOddPrint
{
    public static void Main(string[] args)
    {
        // Creating two threads and assigning methods to them
        Thread t1 = new Thread(Task1); // will print even numbers
        Thread t2 = new Thread(Task2); // will print odd numbers

        // Starting both threads
        t1.Start();
        t2.Start();
    }

    // This method will run on Thread 1
    // It prints even numbers from 0 to 98
    private static void Task1()
    {
        for (int i = 0; i < 100; i += 2)
        {
            Thread.Sleep(100); // pause for 100 milliseconds
            Console.Write(i + " ");
        }
    }

    // This method will run on Thread 2
    // It prints odd numbers from 1 to 99
    private static void Task2()
    {
        Console.WriteLine();
        Thread.Sleep(3000); // wait 3 seconds before starting odd numbers

        for (int i = 1; i < 100; i += 2)
        {
            Thread.Sleep(100); // pause for 100 milliseconds
            Console.Write(i + " ");
        }
    }
}
