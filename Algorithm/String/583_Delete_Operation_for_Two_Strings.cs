public class Solution
{
    public int MinDistance(string word1, string word2)
    {
        int n = word1.Length, m = word2.Length;
        var dp = new int[n + 1, m + 1];

        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= m; j++)
            {
                dp[i, j] = word1[i - 1] == word2[j - 1] ?
                    dp[i - 1, j - 1] + 1 :
                    Math.Max(dp[i - 1, j], dp[i, j - 1]);
            }
        }

        int max = dp[n, m];

        return n - max + m - max;
    }
}