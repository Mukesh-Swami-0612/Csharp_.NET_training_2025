using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> a = new List<int>{1,4,7};
        List<int> b = new List<int>{2,3,8};

        List<int> result = new List<int>();

        int i = 0, j = 0;

        while (i < a.Count && j < b.Count)
        {
            if (a[i] <= b[j])
                result.Add(a[i++]);
            else
                result.Add(b[j++]);
        }

        while (i < a.Count)
            result.Add(a[i++]);

        while (j < b.Count)
            result.Add(b[j++]);

        Console.WriteLine(string.Join(", ", result));
    }
}
