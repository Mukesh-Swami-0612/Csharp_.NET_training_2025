using System;

public class Program{
    public string Checker(string str){
        if (string.IsNullOrEmpty(str)){
            return "Please enter a valid email";
        }
        if (!str.Contains("@") || !str.Contains(".")){
            return "This is not a valid email";
        }

        int indexOfAt = str.IndexOf("@");
        int indexOfDot = str.LastIndexOf(".");
        if (indexOfAt < 1 || indexOfDot == indexOfAt + 5 || indexOfDot == str.Length - 1){
            return "Invalid Email Format!";
        }
        return "Valid Email";
    }

    public static void Main(){
        Program pro1 = new Program();
        Console.Write("Enter your email_id: ");
        string email = Console.ReadLine();
        string result = pro1.Checker(email);
        Console.WriteLine("Entered Email: " + email);
        Console.WriteLine("Result: " + result);
    }
}
