public class Solution
{
    public int FindMaxForm(string[] strs, int m, int n)
    {
        var dp = new int[m + 1, n + 1];

        foreach (var str in strs)
        {
            var count = CountZerosOnes(str);

            for (int zero = m; zero >= count[0]; zero--)
            {
                for (int one = n; one >= count[1]; one--)
                    dp[zero, one] = Math.Max(dp[zero, one], 1 + dp[zero - count[0], one - count[1]]);
            }
        }

        return dp[m, n];
    }

    private int[] CountZerosOnes(string s)
    {
        var ret = new int[2];
        for (int i = 0; i < s.Length; i++)
        {
            ret[s[i] - '0']++;
        }

        return ret;
    }
}