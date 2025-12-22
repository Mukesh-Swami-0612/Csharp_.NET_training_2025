
// Question:
// ATM Withdrawal using nested if conditions


using System;
class ATM
{
    static void Main()
    {
        Console.Write("Insert card (1 = Yes): ");
        int card = int.Parse(Console.ReadLine());

        if (card == 1)
        {
            Console.Write("Enter PIN: ");
            int pin = int.Parse(Console.ReadLine());

            if (pin == 1234)
            {
                Console.Write("Enter balance: ");
                int balance = int.Parse(Console.ReadLine());

                Console.Write("Enter withdrawal amount: ");
                int amount = int.Parse(Console.ReadLine());

                if (balance >= amount)
                    Console.WriteLine("Transaction Successful");
                else
                    Console.WriteLine("Insufficient Balance");
            }
            else
            {
                Console.WriteLine("Invalid PIN");
            }
        }
        else
        {
            Console.WriteLine("Please insert card");
        }
    }
}
