public class Solution {
    public bool IsInterleave(string s1, string s2, string s3) {
        int n = s1.Length, m = s2.Length;
        if (s3.Length != n + m)
            return false;
        
        var dp = new bool[n + 1, m + 1];
        
        for (int i = 0; i <= n; i++)
        {
            for (int j = 0; j <= m; j++)
            {
                if (i == 0 && j == 0)
                    dp[i, j] = true;
                else if (i == 0)
                    dp[i, j] = dp[i, j - 1] && s2[j - 1] == s3[i + j - 1];
                else if (j == 0)
                    dp[i, j] = dp[i - 1, j] && s1[i - 1] == s3[i + j - 1];
                else
                {
                    dp[i,j] = (dp[i, j - 1] && s2[j - 1] == s3[i + j - 1]) ||
                        (dp[i - 1, j] && s1[i - 1] == s3[i + j - 1]);
                }
            }
        }
        
        return dp[n, m];
    }
}