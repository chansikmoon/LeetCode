public class Solution {
    public int LengthOfLIS(int[] nums) {
        int[] dp = new int[nums.Length];
        dp[0] = 1;
        int longest = 0;
        for (int i = 1; i < nums.Length; i++)
        {
            int maxLen = 0;
            for (int j = 0; j < i; j++)
            {
                if (nums[j] < nums[i])
                {
                    maxLen = Math.Max(dp[j], maxLen);
                }
            }
            
            dp[i] = maxLen + 1;
            longest = Math.Max(longest, dp[i]);
        }
        
        return longest;
    }
}