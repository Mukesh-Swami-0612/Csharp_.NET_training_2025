using System;

// Custom Exception
class InvalidEntryException : Exception
{
    public InvalidEntryException(string message) : base(message) { }
}

// Utility Class
class EntryUtility
{
    public static bool ValidateEmployeeId(string employeeId)
    {
        if (employeeId == null || employeeId.Length != 10)
            throw new InvalidEntryException("Invalid employee id");

        if (!employeeId.StartsWith("GOAIR/"))
            throw new InvalidEntryException("Invalid employee id");

        string digits = employeeId.Substring(6);
        if (!int.TryParse(digits, out _))
            throw new InvalidEntryException("Invalid employee id");

        return true;
    }

    public static bool ValidateDuration(int duration)
    {
        if (duration < 1 || duration > 5)
            throw new InvalidEntryException("Invalid duration");

        return true;
    }
}

// Main Class
class UserInterface
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            try
            {
                string[] parts = input.Split(':');
                string employeeId = parts[0];
                int duration = int.Parse(parts[2]);

                EntryUtility.ValidateEmployeeId(employeeId);
                EntryUtility.ValidateDuration(duration);

                Console.WriteLine("Valid entry details");
            }
            catch
            {
                Console.WriteLine("Invalid entry details");
            }
        }
    }
}
