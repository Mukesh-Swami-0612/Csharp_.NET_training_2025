
// Problem:
// Reverse a number and check if it is a palindrome

using System;

class PalindromeCheck
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int num = int.Parse(Console.ReadLine());

        int temp = num;
        int reverse = 0;

        // Reverse the number
        while (temp > 0)
        {
            int digit = temp % 10;
            reverse = reverse * 10 + digit;
            temp /= 10;
        }

        Console.WriteLine("Reverse = " + reverse);

        if (reverse == num)
            Console.WriteLine("Palindrome Number");
        else
            Console.WriteLine("Not a Palindrome Number");
    }
}
