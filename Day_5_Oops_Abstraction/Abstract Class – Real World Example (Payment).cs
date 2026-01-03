// Problem: Implement payment system using abstract class

using System;
// Using System namespace to access Console class

// Abstract base class Payment
abstract class Payment
{
    // Field to store payment amount
    public decimal Amount;

    // Constructor of abstract class
    // This runs when any child payment object is created
    public Payment(decimal amount)
    {
        Amount = amount;
    }

    // Concrete (non-abstract) method
    // Shared logic for all payment types
    public void PrintReceipt()
    {
        Console.WriteLine("Receipt Amount: " + Amount);
    }

    // Abstract method
    // Child classes MUST implement their own payment logic
    public abstract void Pay();
}

// UPI payment class inherits from Payment
class UpiPayment : Payment
{
    // Field to store UPI ID
    public string UpiId;

    // Constructor of UpiPayment
    // 'base(amount)' calls Payment constructor
    public UpiPayment(decimal amount, string upiId) : base(amount)
    {
        UpiId = upiId;
    }

    // Implementing abstract method
    public override void Pay()
    {
        Console.WriteLine("Paid " + Amount + " using UPI: " + UpiId);
    }
}

// Main program class
class Program
{
    public static void Main()
    {
        // Polymorphism:
        // Parent class reference holding child class object
        Payment p = new UpiPayment(909, "mukesh@upi");

        // Calls UpiPayment's Pay() method (runtime polymorphism)
        p.Pay();

        // Calls Payment's PrintReceipt() method
        p.PrintReceipt();
    }
}
