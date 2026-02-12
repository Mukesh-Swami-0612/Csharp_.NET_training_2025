using System;
using System.Collections.Generic;
public class Program{
    public static void Main(){
        List<int> list = new List<int>()
        { 
            1, 2, 3, 5, 6, 3, 2, 3, 1, 1, 2, 5 
        };
        HashSet<int> set = new HashSet<int>(list);
        foreach (int s in set){
            Console.WriteLine(s);
        }
    }
}
