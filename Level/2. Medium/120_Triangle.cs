public class Solution
{
    public int MinimumTotal(IList<IList<int>> triangle)
    {
        int n = triangle.Count;

        for (int i = n - 2; i >= 0; i--)
        {
            for (int j = triangle[i].Count - 1; j >= 0; j--)
                triangle[i][j] += Math.Min(triangle[i + 1][j], triangle[i + 1][j + 1]);
        }

        return triangle[0][0];
    }

    private int BruteForce(IList<IList<int>> triangle)
    {
        int n = triangle.Count;
        var dp = new int[n];

        for (int i = 0; i < n; i++)
            dp[i] = triangle[n - 1][i];

        for (int row = n - 2; row >= 0; row--)
        {
            for (int i = 0; i < triangle[row].Count; i++)
            {
                dp[i] = triangle[row][i] + Math.Min(dp[i], dp[i + 1]);
            }
        }

        return dp[0];
    }
}