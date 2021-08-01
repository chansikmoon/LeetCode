public class Solution {
    public int CountSpecialSubsequences(int[] nums) {
        int MOD = 1_000_000_007;
        var dp = new int[3];
        
        foreach (int num in nums)
        {
            dp[num] = ((dp[num] + dp[num]) % MOD + (num > 0 ? dp[num - 1] : 1)) % MOD;
        }
        
        return dp[2];
    }
}