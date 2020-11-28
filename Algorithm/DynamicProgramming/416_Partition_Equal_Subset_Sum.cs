public class Solution {
    public bool CanPartition(int[] nums) {
        int sum = nums.Sum();
        
        if ((sum & 1) == 1)
            return false;
        
        sum /= 2;
        
        int n = nums.Length;
        bool[] dp = new bool[sum + 1];
        dp[0] = true;
        
        foreach (int num in nums)
        {
            for (int i = sum; i > 0; i--)
            {
                if (i >= num)
                {
                    dp[i] = dp[i] || dp[i - num];
                }
            }
        }
        
        return dp[sum];
     }
}