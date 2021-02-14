public class Solution {
    private int[][] dirs = new int[][]
    {
        new int[]{ -1, -1}, new int[]{ -1, 0}, new int[]{ -1, 1},
        new int[]{ 0, -1}, new int[]{ 0, 1},
        new int[]{ 1, -1}, new int[]{ 1, 0}, new int[]{ 1, 1},
    };

     public int ShortestPathBinaryMatrix(int[][] grid) {
        var q = new Queue<Tuple<int, int>>();
        int n = grid.Length, ret = 0;
        q.Enqueue(new Tuple<int, int>(0, 0));
        
        while (q.Count > 0)
        {
            int size = q.Count;
            ret++;
            while (size-- > 0)
            {
                var coor = q.Dequeue();
                int i = coor.Item1, j = coor.Item2;
                
                if (i < 0 || i >= n || j < 0 || j >= n || grid[i][j] == 1)
                    continue;
                
                grid[i][j] = 1;
                if (i == n - 1 && j == n - 1)
                    return ret;
                
                foreach (var dir in dirs)
                {
                    int nextI = dir[0] + i;
                    int nextJ = dir[1] + j;
                    
                    q.Enqueue(new Tuple<int, int>(nextI, nextJ));
                }
            }
        }
        
        return -1;
    }
    
    // DFS tries every possible path to the end and it marks a cell as unvisited after recurring the neighbors after for-loop. 
    // Therefore, DFS won't work.
    public int BruteForceDFS(int[][] grid) 
    {
        int n = grid.Length;
        var visited = new bool[n][];
        for (int i = 0; i < n; i++)
            visited[i] = new bool[n];
        
        var dp = new int[n][];
        for (int i = 0; i < n; i++)
        {
            dp[i] = new int[n];
            for (int j = 0; j < n; j++)
                dp[i][j] = Int32.MaxValue;
        }
        
        if (grid[0][0] == 0)
            DFS(grid, visited, dp, 0, 0, n, 0);
        
        return dp[n-1][n-1] == Int32.MaxValue ? -1 : dp[n-1][n-1];
    }
    
    private void DFS(int[][] grid, bool[][] visited, int[][] dp, int i, int j, int n, int ret)
    {
        if (i < 0 || i >= n || j < 0 || j >= n || visited[i][j] || grid[i][j] == 1)
            return;
        
        if (i == n-1 && j == n-1)
        {
            if (grid[i][j] == 0)
                dp[i][j] = Math.Min(dp[i][j], ret + 1);
            
            return;
        }
        
        dp[i][j] = Math.Min(dp[i][j], ret + 1);
        visited[i][j] = true;
        
        foreach (var dir in dirs)
        {
            int nextI = i + dir[0];
            int nextJ = j + dir[1];
            
            DFS(grid, visited, dp, nextI, nextJ, n, ret + 1);
        }
        
        visited[i][j] = false;
    }
}