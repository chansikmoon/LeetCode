public class Solution {
    public int NumSubarrayBoundedMax(int[] nums, int left, int right) {
        int ret = 0, dp = 0, prev = -1;
        
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] < left)
                ret += dp;
            else if (nums[i] > right)
            {
                dp = 0;
                prev = i;
            }
            else if (nums[i] >= left && nums[i] <= right)
            {
                dp = i - prev;
                ret += dp;
            }
        }
        
        return ret;
    }
}