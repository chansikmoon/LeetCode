public class Solution {
    public int MaxCoins(int[] nums) {
        int[] arr = new int[nums.Length + 2];
        int index = 1;
        foreach (int num in nums)
            if (num > 0)
                arr[index++] = num;
        arr[0] = 1;
        arr[index++] = 1;
            
        int[,] dp = new int[index, index];
        for (int k = 2; k < index; k++)
        {
            for (int left = 0; left < index - k; left++)
            {
                int right = left + k;
                for (int i = left + 1; i < right; i++)
                {
                    dp[left, right] = Math.Max(dp[left, right], 
                                              arr[left] * arr[i] * arr[right] + dp[left,i] + dp[i,right]);
                }
            }
        }
        
        return dp[0, index - 1];
    }
}