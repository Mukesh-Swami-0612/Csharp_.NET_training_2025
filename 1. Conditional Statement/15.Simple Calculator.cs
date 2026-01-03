// Question:
// Simple Calculator using switch

using System;
// Using System namespace for Console input/output

class Calculator
{
    // Program execution starts from Main method
    static void Main()
    {
        // Ask user to enter first number
        Console.Write("Enter first number: ");
        double a = double.Parse(Console.ReadLine());

        // Ask user to enter operator
        Console.Write("Enter operator (+ - * /): ");
        char op = Console.ReadLine()[0];
        // Reads the operator as a character

        // Ask user to enter second number
        Console.Write("Enter second number: ");
        double b = double.Parse(Console.ReadLine());

        // Switch statement to perform calculation based on operator
        switch (op)
        {
            case '+':   // Addition
                Console.WriteLine("Result = " + (a + b));
                break;

            case '-':   // Subtraction
                Console.WriteLine("Result = " + (a - b));
                break;

            case '*':   // Multiplication
                Console.WriteLine("Result = " + (a * b));
                break;

            case '/':   // Division
                Console.WriteLine("Result = " + (a / b));
                break;

            default:    // Invalid operator
                Console.WriteLine("Invalid Operator");
                break;
        }
    }
}
