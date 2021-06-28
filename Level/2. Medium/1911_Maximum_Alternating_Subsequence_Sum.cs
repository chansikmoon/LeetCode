public class Solution {
    public long MaxAlternatingSum(int[] nums) {
        long even = 0, odd = 0;
        
        foreach (var num in nums)
        {
            even = Math.Max(even, odd + num);
            odd = even - num;
        }
        
        return even;
    }
}