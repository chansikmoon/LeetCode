public class Solution {
    public int MaxAreaOfIsland(int[][] grid) {
        int n = grid.Length, m = grid[0].Length;
        var dir = new int[] { 0 , -1 , 0 , 1 , 0 };
        
        int max = 0;
        
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                max = Math.Max(max, DFS(grid, dir, i, j, n, m));
            }
        }
        
        return max;
    }
    
    private int DFS(int[][] grid, int[] dir, int i, int j, int n, int m)
    {
        if (i < 0 || i >= n || j < 0 || j >= m || grid[i][j] != 1)
            return 0;
        
        grid[i][j] = 0;
        int ret = 1;
        
        for (int k = 1; k < 5; k++)
        {
            ret += DFS(grid, dir, i + dir[k-1], j + dir[k], n, m);
        }
        
        return ret;
    }
}