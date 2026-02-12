using System;
using System.Collections.Generic;

public class Program{
    public void Freq(int[] nums){
        Dictionary<int, int> dict = new Dictionary<int, int>();
        int len = nums.Length;
        foreach (int n in nums){
            int fr = 0;
            for (int i = 0; i < len; i++){
                if (nums[i] == n){
                    fr++;
                }
            }
            if (!dict.ContainsKey(n)){
                dict.Add(n, fr);
            }
        }
        foreach (var item in dict)
        {
            Console.WriteLine($"{item.Key} : {item.Value}");
        }
    }

    public static void Main(){
        Program p1 = new Program();
        int[] arr = { 1, 2, 3, 4, 2, 3, 2, 3, 2, 3, 4 };
        p1.Freq(arr);
    }
}
