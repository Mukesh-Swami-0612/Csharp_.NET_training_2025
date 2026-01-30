// namespace MyLibrary;

// public class Calculator
// {
//     public int Add(int a, int b) => a + b;

//     public double Divide(double a, double b)
//     {
//         if (b == 0)
//             throw new DivideByZeroException("Cannot divide by zero.");
//         return a / b;
//     }

//     public string GetGreeting(string name) => $"Hello, {name}!";
// }

namespace MyLibrary;

public class Calculator
{
    public int Add(int a, int b)
    {
        return a + b;
    }

    // 1. DivideByZeroException
    public double Divide(double a, double b)
    {
        if (b == 0)
            throw new DivideByZeroException("Cannot divide by zero");

        return a / b;
    }

    // 2. ArgumentNullException
    public string GetGreeting(string name)
    {
        if (name == null)
            throw new ArgumentNullException(nameof(name), "Name cannot be null");

        return $"Hello, {name}!";
    }

    // 3. ArgumentOutOfRangeException
    public int SquareRoot(int number)
    {
        if (number < 0)
            throw new ArgumentOutOfRangeException(nameof(number), "Number cannot be negative");

        return (int)Math.Sqrt(number);
    }
}
