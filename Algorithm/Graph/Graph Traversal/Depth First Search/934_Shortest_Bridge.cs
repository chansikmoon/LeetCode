public class Solution {
    private int[] dir;
    
    public int ShortestBridge(int[][] grid) {        
        int n = grid.Length;
        dir = new int[] { 0, -1, 0, 1, 0 };

        var q = new Queue<(int r, int c)>();
        var visited = new bool[n,n];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] == 1)
                {
                    DFS(grid, visited, q, i, j, n);
                    break;
                }
            }
            
            if (q.Count > 0)
                break;
        }
        
        int ret = 0;
        
        while (q.Count > 0)
        {
            int size = q.Count;
            
            while (size-- > 0)
            {
                var coor = q.Dequeue();
                
                for (int i = 1; i < 5; i++)
                {
                    int newRow = coor.r + dir[i-1];
                    int newCol = coor.c + dir[i];
                    
                    if (newRow >= 0 && newRow < n && newCol >= 0 && 
                        newCol < n && !visited[newRow, newCol])
                    {
                        if (grid[newRow][newCol] == 1)
                            return ret;
                        
                        q.Enqueue((newRow, newCol));
                        visited[newRow, newCol] = true;
                    }
                }
            }
            
            ret++;
        }
        
        return 0;
    }    
    
    private void DFS(int[][] grid, bool[,] visited, Queue<(int r, int c)> q, 
                    int r, int c, int n)
    {
        if (r < 0 || r >= n || c < 0 || c >= n || visited[r, c] || grid[r][c] == 0)
            return;
        
        visited[r, c] = true;
        q.Enqueue((r, c));
        
        for (int i = 1; i < 5; i++)
        {
            int newRow = r + dir[i-1];
            int newCol = c + dir[i];
            
            DFS(grid, visited, q, newRow, newCol, n);
        }
    }
}