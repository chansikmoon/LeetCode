public class Solution {
    public int NumberOfArithmeticSlices(int[] nums) {
        var dp = new int[nums.Length];
        int ret = 0;
        
        for (int i = 2; i < nums.Length; i++) {
            if (nums[i - 2] - nums[i - 1] == nums[i - 1] - nums[i]) {
                dp[i] = dp[i - 1] + 1;
                ret += dp[i];
            }
        }
        
        return ret;
    }
}