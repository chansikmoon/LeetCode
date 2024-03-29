public class Solution
{
    public int UniquePathsWithObstacles(int[][] obstacleGrid)
    {
        int m = obstacleGrid.Length;
        int n = obstacleGrid[0].Length;
        var dp = new int[m + 1, n + 1];
        
        dp[1, 0] = 1;
        
        for (int i = 1; i <= m; i++) {
            for (int j = 1; j <= n; j++) {
                if (obstacleGrid[i-1][j-1] == 0) {
                    dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
                }
            }
        }
        
        return dp[m, n];
    }
}