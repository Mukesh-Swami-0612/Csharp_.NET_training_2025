using System;
public class Program{
    public string Reverse(string rev){
        string r = "";
        int n = rev.Length;
        for (int i = n - 1; i >= 0; i--){
            r += rev[i]; 
        }
        return r;
    }

    public static void Main(){
        Program p1 = new Program();
        Console.Write("Please enter a string: ");
        string str = Console.ReadLine();
        string result = p1.Reverse(str);
        Console.WriteLine("Reversed String: " + result);
    }
}
