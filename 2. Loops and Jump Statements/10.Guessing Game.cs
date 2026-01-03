// Problem:
// Guess the secret number using do-while loop

using System;
// Using System namespace for Console input/output

class GuessingGame
{
    // Program execution starts from Main method
    static void Main()
    {
        // Secret number to be guessed
        int secret = 7;

        // Variable to store user's guess
        int guess;

        // do-while loop
        // This loop runs at least once
        do
        {
            // Ask user to guess the number
            Console.Write("Guess the number: ");

            // Read user's guess
            guess = int.Parse(Console.ReadLine());

        } 
        // Loop continues until guess equals secret number
        while (guess != secret);

        // This line runs when correct guess is made
        Console.WriteLine("You guessed it right!");
    }
}
