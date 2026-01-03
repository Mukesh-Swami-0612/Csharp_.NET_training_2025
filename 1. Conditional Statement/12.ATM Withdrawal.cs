// Question:
// ATM Withdrawal using nested if conditions

using System;
// Using System namespace for Console input/output

class ATM
{
    // Program execution starts from Main method
    static void Main()
    {
        // Ask user to insert card
        Console.Write("Insert card (1 = Yes): ");
        int card = int.Parse(Console.ReadLine());

        // Check if card is inserted
        if (card == 1)
        {
            // Ask for PIN
            Console.Write("Enter PIN: ");
            int pin = int.Parse(Console.ReadLine());

            // Check if PIN is correct
            if (pin == 1234)
            {
                // Ask for available balance
                Console.Write("Enter balance: ");
                int balance = int.Parse(Console.ReadLine());

                // Ask for withdrawal amount
                Console.Write("Enter withdrawal amount: ");
                int amount = int.Parse(Console.ReadLine());

                // Check if balance is sufficient
                if (balance >= amount)
                    Console.WriteLine("Transaction Successful");
                else
                    Console.WriteLine("Insufficient Balance");
            }
            else
            {
                // PIN is incorrect
                Console.WriteLine("Invalid PIN");
            }
        }
        else
        {
            // Card is not inserted
            Console.WriteLine("Please insert card");
        }
    }
}
