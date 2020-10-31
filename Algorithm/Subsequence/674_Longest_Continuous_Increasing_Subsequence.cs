public class Solution {
    public int FindLengthOfLCIS(int[] nums) {
        if (nums.Length == 0)
            return 0;
        
        int longest = 1, pre = nums[0], count = 1;
        
        for (int i = 1; i < nums.Length; i++)
        {
            if (pre < nums[i])
            {
                count++;
                longest = Math.Max(longest, count);
            }
            else
                count = 1;
            
            pre = nums[i];
        }
        
        return longest;
    }
}