public class Solution
{
    public int LongestCommonSubsequence(string text1, string text2)
    {
        int n = text1.Length, m = text2.Length;
        var dp = new int[n + 1, m + 1];

        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= m; j++)
            {
                dp[i, j] = text1[i - 1] == text2[j - 1] ? dp[i - 1, j - 1] + 1 : Math.Max(dp[i - 1, j], dp[i, j - 1]);
            }
        }

        return dp[n, m];
    }
}