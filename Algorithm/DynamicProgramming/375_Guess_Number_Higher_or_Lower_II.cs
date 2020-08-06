public class Solution {
    public int GetMoneyAmount(int n) {
        int[,] dp = new int[n + 1, n + 1];

        for (int len = 1; len < n; len++)
        {
            for (int i = 1; i + len <= n; i++)
            {
                int j = i + len;
                dp[i,j] = Int32.MaxValue;

                for (int k = i; k < j; k++)
                {
                    dp[i,j] = Math.Min(dp[i,j], k + Math.Max(dp[i,k - 1], dp[k + 1,j]));
                }
            }
        }

        return dp[1,n];
    }
}