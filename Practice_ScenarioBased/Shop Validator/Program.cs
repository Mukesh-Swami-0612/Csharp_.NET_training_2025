using System;
using System.Text.RegularExpressions;

// Custom Exception
class InvalidGadgetException : Exception
{
    public InvalidGadgetException(string message) : base(message) { }
}

// Utility Class
class GadgetValidatorUtil
{
    public static bool ValidateGadgetID(string gadgetID)
    {
        if (!Regex.IsMatch(gadgetID, "^[A-Z][0-9]{3}$"))
            throw new InvalidGadgetException("Invalid gadget ID");

        return true;
    }

    public static bool ValidateWarrantyPeriod(int period)
    {
        if (period < 6 || period > 36)
            throw new InvalidGadgetException("Invalid warranty period");

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
                string gadgetID = parts[0];
                int warranty = int.Parse(parts[2]);

                GadgetValidatorUtil.ValidateGadgetID(gadgetID);
                GadgetValidatorUtil.ValidateWarrantyPeriod(warranty);

                Console.WriteLine("Warranty accepted, stock updated");
            }
            catch (InvalidGadgetException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
