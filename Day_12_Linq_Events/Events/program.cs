using System;

namespace LearningCSharp
{
    public class EventExample
    {
        // Step 1: Create a delegate (it works like a method pointer)
        // This delegate can point to any method that returns void and takes no parameters
        public delegate void Notify();

        // Step 2: Create an event using the delegate
        // Event will be triggered when number is greater than 500
        public static event Notify Reached500;

        public static void Main()
        {
            // Step 3: Subscribe (attach) a method to the event
            // This means whenever event is triggered, this method will run
            Reached500 += ValueReached500Plus;

            // Infinite loop (keeps running until user types exit)
            while (true)
            {
                Console.WriteLine("Enter a number (or 'exit' to quit): ");
                string input = Console.ReadLine();

                // If user types exit, stop the program
                if (input.ToLower() == "exit")
                    break;

                try
                {
                    // Convert input string into integer
                    var num = int.Parse(input);

                    // If number is more than 500, trigger the event
                    if (num > 500)
                    {
                        // Calling event (all subscribed methods will run)
                        Reached500();
                    }

                    // Setting num to 0 (not necessary, but you wrote it)
                    num = 0;
                }
                catch (FormatException)
                {
                    // If input is not a number (example: abc), this catch runs
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
        }

        // This is the event handler method
        // It will run when event is triggered
        private static void ValueReached500Plus()
        {
            Console.WriteLine("Yes Reached 500 or 500 plus please note");
        }
    }
}

