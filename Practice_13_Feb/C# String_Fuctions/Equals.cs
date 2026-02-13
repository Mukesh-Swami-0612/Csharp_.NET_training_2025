using System;

class Program
{
    static void Main()
    {
        char a = 'A';
        char b = 'a';
        bool same = char.ToUpper(a).Equals(char.ToUpper(b));
        Console.WriteLine("Same: " + same);
        string s = "book";
        for (int i = 0; i < s.Length - 1; i++)
        {
            if (s[i] == s[i + 1])
                Console.WriteLine("Duplicate: " + s[i]);
        }
    }
}
