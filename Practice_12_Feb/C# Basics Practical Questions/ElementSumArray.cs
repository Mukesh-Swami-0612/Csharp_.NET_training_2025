using System;
public class Program{
    public int ElementSum(int[] nums){
        int sum = 0;
        for(int i =0;i<nums.Length;i++){
            sum+=nums[i];
        }
        return sum;
    }
    public static void Main(){
        Program p1 = new Program();
        int[] arr = {1,2,3,4,5,4,3,2,1};
        int sum = p1.ElementSum(arr);
        Console.WriteLine("Sum of all elements of arr: " +sum);
    }
}
