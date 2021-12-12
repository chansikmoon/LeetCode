public class Solution {
    public bool CanPartition(int[] nums) {
        int total = nums.Sum();
        
        if ((total & 1) > 0)
            return false;
        
        int target = total / 2;
        var dp = new bool[target + 1];
        dp[0] = true;
        
        foreach (var num in nums)
        {
            for (int i = target; i > 0; i--)
            {
                if (i >= num)
                    dp[i] = dp[i] || dp[i - num];
            }
        }
        
        return dp[target];
    }
}