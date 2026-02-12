using System;
public class Program{
    public bool CheckPalindrome(string s){
        if (string.IsNullOrEmpty(s)){
            return false;
        }
            int i=0;
            int j=s.Length-1;
            while(i<j){
                if(s[i]==s[j]){
                    i++;
                    j--;
                }
                else{
                    return false;
                }
            }
            return true;
        }
    public static void Main(){
        Program p1 = new Program();
        Console.Write("Please enter a string: ");
        string str = Console.ReadLine();
        p1.CheckPalindrome(str);
        bool result = p1.CheckPalindrome(str);
        Console.WriteLine(result);
    }
}
