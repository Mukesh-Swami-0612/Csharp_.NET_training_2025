
using System;

class BankAccount
{
    static void Main()
    {
        int balance = 10000;

        Console.WriteLine("Enter withdrawal amount:");

        try
        {
            int amount = int.Parse(Console.ReadLine());

            if (amount <= 0)
            {
                throw new ArgumentException("Amount must be greater than 0.");
            }

            if (amount > balance)
            {
                throw new InvalidOperationException("Insufficient balance.");
            }

            balance -= amount;

            Console.WriteLine("Withdrawal Successful!");
            Console.WriteLine("Remaining Balance: " + balance);
        }
        catch (FormatException)
        {
            Console.WriteLine("Please enter a valid number.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected Error: " + ex.Message);
        }
        finally
        {
            Console.WriteLine("Transaction Completed.");
        }
    }
}
