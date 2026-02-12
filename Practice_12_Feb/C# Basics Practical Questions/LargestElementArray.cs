using System;
public class Program{
    public int LargestElement(int[] nums){
        int element = nums[0];
        for(int i =0;i<nums.Length;i++){
            if(element<nums[i]){
                element=nums[i];
            }
        }
        return element;
    }
    public static void Main(){
        Program p1 = new Program();
        int[] arr = {2,3,-1,5,7,8};
        int result = p1.LargestElement(arr);
        Console.WriteLine("Largest element of array: "+result);
    }
}
