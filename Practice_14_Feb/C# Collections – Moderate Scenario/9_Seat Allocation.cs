using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int n = 5;
        List<int> booked = new List<int>{2,4};
        int requests = 5;

        SortedSet<int> available = new SortedSet<int>();

        for (int i = 1; i <= n; i++)
            available.Add(i);

        foreach (int seat in booked)
            available.Remove(seat);

        List<int> allocated = new List<int>();

        for (int i = 0; i < requests; i++)
        {
            if (available.Count == 0)
            {
                allocated.Add(-1);
            }
            else
            {
                int seat = available.Min;
                allocated.Add(seat);
                available.Remove(seat);
            }
        }

        Console.WriteLine(string.Join(", ", allocated));
    }
}
