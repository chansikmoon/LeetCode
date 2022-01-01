public class Solution {
    public int MaxCoins(int[] nums) {
        var ballons = new int[nums.Length + 2];
        int length = 1;
        
        foreach (int num in nums)
        {
            if (num > 0)
            {
                ballons[length++] = num;
            }
        }
        
        ballons[0] = 1;
        ballons[length++] = 1;
        
        var dp = new int[length, length];
        
        for (int k = 2; k < length; k++)
        {
            for (int left = 0; left < length - k; left++)
            {
                int right = left + k;
                
                for (int middle = left + 1; middle < right; middle++)
                {
                    dp[left, right] = Math.Max(dp[left, right], 
                                               ballons[left] * ballons[middle] * ballons[right] + 
                                               dp[left, middle] + dp[middle, right]);
                }
            }
        }
        
        return dp[0, length - 1];
    }
}