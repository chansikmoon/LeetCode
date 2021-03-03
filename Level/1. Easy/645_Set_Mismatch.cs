public class Solution {
    public int[] FindErrorNums(int[] nums) {
        int dup = -1, mis = 1;
        
        for (int i = 0; i < nums.Length; i++)
        {
            int n = Math.Abs(nums[i]);
            if (nums[n - 1] < 0)
                dup = n;
            else
                nums[n - 1] *= -1;
        }
        
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] > 0)
                mis = i + 1;
        }
        
        return new int[] { dup, mis};
    }
}