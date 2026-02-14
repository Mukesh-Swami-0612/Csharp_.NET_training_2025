using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> ops = new List<string>
        {
            "TYPE Hello",
            "TYPE World",
            "UNDO",
            "TYPE CSharp"
        };

        Stack<string> stack = new Stack<string>();

        foreach (string op in ops)
        {
            if (op.StartsWith("TYPE "))
            {
                string word = op.Substring(5);
                stack.Push(word);
            }
            else if (op == "UNDO" && stack.Count > 0)
            {
                stack.Pop();
            }
        }

        string[] words = stack.ToArray();
        Array.Reverse(words);

        Console.WriteLine(string.Join(" ", words));
    }
}
