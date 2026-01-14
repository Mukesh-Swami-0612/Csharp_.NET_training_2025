using System;
using System.Linq;

class PalindromeLinq
{
    static void Main(string[] args)
    {
        // Array of names / strings
        string[] names = { "A", "B", "C", "MADAM", "MUKESH", "NOON" };

        // LINQ Query: Sort names and check palindrome for each name
        var findNames = from nam in names
                        orderby nam ascending
                        select IsPalindrome(nam);

        // Print each result
        foreach (var item in findNames)
        {
            Console.WriteLine(item);
        }
    }

    // Method to check if a string is palindrome
    public static string IsPalindrome(string name)
    {
        // Reverse the string using LINQ Reverse()
        string rev = new string(name.Reverse().ToArray());

        // Compare original and reversed string
        if (rev == name)
        {
            return "Palindrome : " + name;
        }

        return "Not a Palindrome : " + name;
    }
}
