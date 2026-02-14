using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Queue<(TimeSpan, string)> q = new Queue<(TimeSpan, string)>();
        q.Enqueue((new TimeSpan(8,30,0), "Regular"));
        q.Enqueue((new TimeSpan(9,0,0), "Regular"));
        q.Enqueue((new TimeSpan(11,0,0), "Regular"));
        q.Enqueue((new TimeSpan(8,45,0), "VIP"));

        int count = 0;
        TimeSpan start = new TimeSpan(8,0,0);
        TimeSpan end = new TimeSpan(10,0,0);

        while (q.Count > 0)
        {
            var item = q.Dequeue();

            if (item.Item2 == "Regular" &&
                item.Item1 >= start &&
                item.Item1 <= end)
            {
                count++;
            }
        }

        Console.WriteLine("Regular Peak Count: " + count);
    }
}
