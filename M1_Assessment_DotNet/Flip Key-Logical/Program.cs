using System;

class Program
{
    public static string CleanseAndInvert(string input)
    {
        // Check null or minimum length
        if (string.IsNullOrEmpty(input) || input.Length < 6)
        {
            return "";
        }

        // Check only alphabets allowed
        foreach (char ch in input)
        {
            if (!char.IsLetter(ch))
            {
                return "";
            }
        }

        // Convert to lowercase
        input = input.ToLower();

        string filtered = "";

        // Remove even ASCII characters
        foreach (char ch in input)
        {
            int ascii = (int)ch;

            if (ascii % 2 != 0) // keep odd ASCII
            {
                filtered += ch;
            }
        }

        // Reverse the string
        char[] arr = filtered.ToCharArray();
        Array.Reverse(arr);
        string reversed = new string(arr);

        // Make even index letters uppercase
        char[] result = reversed.ToCharArray();

        for (int i = 0; i < result.Length; i++)
        {
            if (i % 2 == 0)
            {
                result[i] = char.ToUpper(result[i]);
            }
        }

        return new string(result);
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Enter the word");

        // Read input
        string input = Console.ReadLine();

        // Process input
        string output = CleanseAndInvert(input);

        // Print result
        if (output == "")
        {
            Console.WriteLine("Invalid Input");
        }
        else
        {
            Console.WriteLine("The generated key is - " + output);
        }
    }
}
