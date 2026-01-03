// Problem:
// Create a menu-driven program using do-while and switch

using System;
// Using System namespace for Console input/output

class MenuSystem
{
    // Program execution starts from Main method
    static void Main()
    {
        // Variable to store user's menu choice
        int choice;

        // do-while loop
        // Menu will be shown at least once
        do
        {
            // Display menu options
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Subtract");
            Console.WriteLine("3. Exit");
            Console.Write("Enter choice: ");

            // Read user's choice
            choice = int.Parse(Console.ReadLine());

            // switch statement to handle menu choice
            switch (choice)
            {
                case 1:
                    // Option 1 selected
                    Console.WriteLine("Addition selected");
                    break;

                case 2:
                    // Option 2 selected
                    Console.WriteLine("Subtraction selected");
                    break;

                case 3:
                    // Exit option
                    Console.WriteLine("Exiting...");
                    break;

                default:
                    // Invalid option handling
                    Console.WriteLine("Invalid choice");
                    break;
            }

        } 
        // Loop continues until user selects Exit (3)
        while (choice != 3);
    }
}
