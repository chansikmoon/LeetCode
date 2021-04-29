public class Solution
{
    public int UniquePathsWithObstacles(int[][] obstacleGrid)
    {
        if (obstacleGrid.Length == 0)
            return 0;

        int n = obstacleGrid.Length, m = obstacleGrid[0].Length;
        var dp = new int[n + 1, m + 1];
        dp[0, 1] = 1;

        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= m; j++)
            {
                if (obstacleGrid[i - 1][j - 1] == 0)
                    dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
                else
                    dp[i, j] = 0;
            }
        }

        return dp[n, m];
    }
}