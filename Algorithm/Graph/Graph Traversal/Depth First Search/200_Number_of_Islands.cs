public class Solution {
    private int[] dir = new int[] { 0, 1, 0, -1, 0 };
    
    public int NumIslands(char[][] grid) {
        int m = grid.Length, n = grid[0].Length, ret = 0;
        
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] == '1')
                {
                    DFS(grid, i, j);
                    ret++;
                }
            }
        }
        
        return ret;
    }
    
    private void DFS(char[][] grid, int i, int j)
    {
        int m = grid.Length, n = grid[0].Length;
        
        if (i < 0 || i >= m || j < 0 || j >= n || grid[i][j] != '1')
            return;
        
        grid[i][j] = '0';
        
        for (int d = 1; d < 5; d++)
        {
            int nextX = i + dir[d - 1];
            int nextY = j + dir[d];
            
            DFS(grid, nextX, nextY);
        }
    }
}