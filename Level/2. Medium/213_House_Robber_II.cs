public class Solution {
    public int Rob(int[] nums) {
        if (nums.Length == 1)
            return nums[0];
        
        return Math.Max(RobFunction(nums, 0, nums.Length - 1), RobFunction(nums, 1, nums.Length));
    }
    
    public int RobFunction(int[] nums, int i, int j)
    {
        int prev = 0, cur = 0;
        
        for (; i < j; i++)
        {
            int temp = cur;
            cur = Math.Max(prev + nums[i], cur);
            prev = temp;
        }
        
        return cur;
    }
}