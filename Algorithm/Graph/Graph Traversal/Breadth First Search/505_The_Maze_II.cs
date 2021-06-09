public class Solution {
    private int[] dir = new int[]
    {
        0, 1, 0, -1, 0
    };
    
    public int ShortestDistance(int[][] maze, int[] start, int[] dest) {
        int m = maze.Length, n = maze[0].Length;
    
        var cost = new int[m,n];
        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++)
                cost[i,j] = Int32.MaxValue;
        
        cost[start[0], start[1]] = 0;
        
        var q = new Queue<(int x, int y, int z)>();
        q.Enqueue((start[0], start[1], 0));
        
        while (q.Count > 0)
        {
            int size = q.Count;
            
            while (size-- > 0)
            {
                var coor = q.Dequeue();
                int x = coor.x;
                int y = coor.y;
                int z = coor.z;
                
                for (int i = 1; i < 5; i++)
                {
                    var next = GetNextCoor(maze, i, x, y);
                    int nextX = next[0];
                    int nextY = next[1];
                    int nextZ = next[2];
                    
                    var newCost = cost[x, y] + nextZ;
                    
                    if (newCost < cost[nextX, nextY])
                    {
                        cost[nextX, nextY] = newCost;
                        
                        if (nextX != dest[0] || nextY != dest[1])
                            q.Enqueue((nextX, nextY, nextZ));
                    }
                }
            }
        }
        
        return cost[dest[0], dest[1]] == Int32.MaxValue ? -1 : cost[dest[0], dest[1]];
    }
    
    private int[] GetNextCoor(int[][] maze, int i, int x, int y)
    {
        var ret = new int[] { x, y, 0 };
        
        while (IsValid(maze, ret[0] + dir[i - 1], ret[1] + dir[i]))
        {
            ret[0] += dir[i - 1];
            ret[1] += dir[i];
            ret[2]++;
        }
        
        return ret;
    }
    
    private bool IsValid(int[][] maze, int x, int y)
    {
        int m = maze.Length;
        int n = maze[0].Length;
        
        if (x < 0 || x >= m || y < 0 || y >= n) 
            return false;
        
        return maze[x][y] == 0;
    }
}