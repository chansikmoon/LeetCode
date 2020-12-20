public class Solution {
    // Time: O(9 * m * n^2)
    // space: O(m * n^2)
    public int CherryPickup(int[][] grid) {
        int m = grid.Length, n = grid[0].Length;
        int?[,,] dp = new int?[m,n,n];
        
        return DFS(grid, dp, 0, 0, n - 1, m, n);
    }
    
    public int DFS(int[][] grid, int?[,,] dp, int r, int c1, int c2, int m, int n)
    {
        // bottom
        if (r == m)
            return 0;
        
        if (dp[r,c1,c2].HasValue)
            return dp[r,c1,c2].Value;
        
        int ans = 0;
            
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                int nc1 = c1 + i, nc2 = c2 + j;
                if (nc1 >= 0 && nc1 < n && nc2 >= 0 && nc2 < n)
                {
                    ans = Math.Max(ans, DFS(grid, dp, r + 1, nc1, nc2, m, n));    
                }
            }
        }
        
        int cherries = c1 == c2 ? grid[r][c1] : grid[r][c1] + grid[r][c2];
        dp[r,c1,c2] = ans + cherries;
        return dp[r,c1,c2].Value;
    }
}