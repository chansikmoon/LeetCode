public class Solution {
    public int NumDistinctIslands(int[][] grid) {
        var _set = new HashSet<string>();
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[0].Length; j++)
            {
                if (grid[i][j] == 1)
                {
                    var sb = new StringBuilder();
                    DFS(grid, i, j, sb, "s");
                    grid[i][j] = 0;
                    _set.Add(sb.ToString());
                }
            }
        }
        
        return _set.Count;
    }
    
    private void DFS(int[][] grid, int i, int j, StringBuilder sb, string dir)
    {
        if (i < 0 || i >= grid.Length || j < 0 || j >= grid[0].Length || grid[i][j] == 0)
            return;
        
        sb.Append(dir);
        grid[i][j] = 0;
        
        DFS(grid, i-1, j, sb, "u");
        DFS(grid, i, j+ 1, sb, "r");
        DFS(grid, i+1, j, sb, "d");
        DFS(grid, i, j-1, sb, "l");
        sb.Append("b");
    }
}