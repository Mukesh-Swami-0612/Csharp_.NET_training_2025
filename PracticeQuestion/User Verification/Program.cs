using System;

public class User
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
}

public class InvalidPhoneNumberException : Exception
{
    public InvalidPhoneNumberException() : base("Invalid phone number")
    {
    }
}

public class Program
{
    public static User ValidatePhoneNumber(string name, string phoneNumber)
    {
        if (phoneNumber.Length != 10)
        {
            throw new InvalidPhoneNumberException();
        }

        return new User
        {
            Name = name,
            PhoneNumber = phoneNumber
        };
    }

    public static void Main(string[] args)
    {
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("ph: ");
        string phoneNumber = Console.ReadLine();

        try
        {
            User user = ValidatePhoneNumber(name, phoneNumber);
            Console.WriteLine("Valid phone number");
        }
        catch (InvalidPhoneNumberException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
