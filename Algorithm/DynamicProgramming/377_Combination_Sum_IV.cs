public class Solution
{
    public int CombinationSum4(int[] nums, int target)
    {
        var dp = new int[target + 1];
        for (int i = 0; i <= target; i++)
            dp[i] = -1;
        dp[0] = 1;

        return Helper(dp, nums, target);
    }

    private int Helper(int[] dp, int[] nums, int target)
    {
        if (dp[target] >= 0)
            return dp[target];

        int ret = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (target >= nums[i])
            {
                ret += Helper(dp, nums, target - nums[i]);
            }
        }

        dp[target] = ret;

        return ret;
    }
}