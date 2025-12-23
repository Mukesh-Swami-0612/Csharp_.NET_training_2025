// Question:
// Rock Paper Scissors game using nested if

using System;
// Using System namespace for Console input/output

class RockPaperScissors
{
    // Program execution starts from Main method
    static void Main()
    {
        // Take input from Player 1
        Console.Write("Player 1 (R/P/S): ");
        char p1 = char.ToUpper(Console.ReadLine()[0]);
        // Convert input to uppercase to avoid case issues

        // Take input from Player 2
        Console.Write("Player 2 (R/P/S): ");
        char p2 = char.ToUpper(Console.ReadLine()[0]);

        // If both players choose the same option
        if (p1 == p2)
            Console.WriteLine("Draw");

        // Conditions where Player 1 wins
        // R beats S, S beats P, P beats R
        else if (p1 == 'R' && p2 == 'S' ||
                 p1 == 'S' && p2 == 'P' ||
                 p1 == 'P' && p2 == 'R')
            Console.WriteLine("Player 1 Wins");

        // Remaining cases → Player 2 wins
        else
            Console.WriteLine("Player 2 Wins");
    }
}
