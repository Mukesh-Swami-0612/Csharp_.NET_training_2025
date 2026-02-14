using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var players = new List<(string, int)>
        {
            ("Raj",80),
            ("Anu",95),
            ("Vikram",95),
            ("Meena",70)
        };

        int k = 3;

        players.Sort((a,b) =>
        {
            if (b.Item2 != a.Item2)
                return b.Item2.CompareTo(a.Item2);
            else
                return a.Item1.CompareTo(b.Item1);
        });

        for (int i = 0; i < k && i < players.Count; i++)
        {
            Console.WriteLine(players[i].Item1 + " : " + players[i].Item2);
        }
    }
}
