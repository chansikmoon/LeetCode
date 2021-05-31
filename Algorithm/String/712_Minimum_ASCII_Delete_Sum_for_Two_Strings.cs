public class Solution
{
    public int MinimumDeleteSum(string s1, string s2)
    {
        int n = s1.Length, m = s2.Length;
        int str1 = 0, str2 = 0;

        for (int i = 0; i < n; i++)
            str1 += (int)s1[i];

        for (int i = 0; i < m; i++)
            str2 += (int)s2[i];

        var dp = new int[n + 1, m + 1];

        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= m; j++)
            {
                dp[i, j] = s1[i - 1] == s2[j - 1] ?
                    dp[i - 1, j - 1] + (int)s1[i - 1] :
                    Math.Max(dp[i - 1, j], dp[i, j - 1]);
            }
        }

        int max = dp[n, m];

        return str1 - max + str2 - max;
    }
}