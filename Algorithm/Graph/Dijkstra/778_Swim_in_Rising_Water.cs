public class Solution {
    private int[] Direction = new int[] { 0, 1, 0, -1, 0 };
    
    public int SwimInWater(int[][] grid) {
        int n = grid.Length;
        
        var cost = new int[n,n];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                cost[i,j] = Int32.MaxValue;
        
        var q = new Queue<(int x, int y, int z)>();
        q.Enqueue((0, 0, grid[0][0]));
        cost[0, 0] = grid[0][0];
        
        while (q.Count > 0)
        {
            var curr = q.Dequeue();
            int x = curr.x;
            int y = curr.y;
            int z = curr.z;
            
            for (int dir = 1; dir < 5; dir++)
            {
                int nextX = x + Direction[dir - 1];
                int nextY = y + Direction[dir];
                
                if (nextX < 0 || nextX >= n || nextY < 0 || nextY >= n)
                    continue;
                
                int nextZ= Math.Max(grid[nextX][nextY], z);

                if (nextZ < cost[nextX, nextY])
                {
                    cost[nextX, nextY] = nextZ;
                    
                    if (nextX != n-1 || nextY != n-1)  
                        q.Enqueue((nextX, nextY, cost[nextX,nextY]));
                }
            }
        }
        
        return cost[n-1, n-1];
    }
}