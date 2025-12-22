
// Question:
// Simple Calculator using switch

using System;

class Calculator
{
    static void Main()
    {
        Console.Write("Enter first number: ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("Enter operator (+ - * /): ");
        char op = Console.ReadLine()[0];

        Console.Write("Enter second number: ");
        double b = double.Parse(Console.ReadLine());

        switch (op)
        {
            case '+':
                Console.WriteLine("Result = " + (a + b));
                break;
            case '-':
                Console.WriteLine("Result = " + (a - b));
                break;
            case '*':
                Console.WriteLine("Result = " + (a * b));
                break;
            case '/':
                Console.WriteLine("Result = " + (a / b));
                break;
            default:
                Console.WriteLine("Invalid Operator");
                break;
        }
    }
}

