// Time Complexity: O(mnk), for every cell (m*n), in the worst case we have to put that cell into the queue k times.
// Space Complexity: O(mnk)
public class Solution {
    public int ShortestPath(int[][] grid, int k) {
        int m = grid.Length, n = grid[0].Length, steps = 0;
        
        int[][] directions = new int[4][]
        {
            new int[] {-1, 0},
            new int[] {0, 1},
            new int[] {1, 0},
            new int[] {0, -1},
        };
        
        int[,] visited = new int[m,n];
        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++)
                visited[i,j] = Int32.MaxValue;
        
        visited[0,0] = 0;
        
        // x, y, numOfObstaclesPassed
        Queue<int[]> q = new Queue<int[]>();
        q.Enqueue(new int[]{0,0,0});
        
        while (q.Count > 0)
        {
            int size = q.Count;
            while (size-- > 0)
            {
                int[] coor = q.Dequeue();
                
                // The lower right corner
                if (coor[0] == m - 1 && coor[1] == n - 1)
                    return steps;
                
                foreach (int[] dir in directions)
                {
                    int x = coor[0] + dir[0], y = coor[1] + dir[1];
                    
                    // out of bounds
                    if (x < 0 || x >= m || y < 0 || y >= n) 
                        continue;
                    
                    // grid[x][y]: Either it is an empty cell or an obstacle
                    // coor[2]: The number of obstacles passed so far
                    int numOfObstaclesPassed = grid[x][y] + coor[2];
                    
                    // numOfObstaclesPassed >= visited[x,y]: true - already visited or not optimal
                    // numOfObstaclesPassed > k: true - can't pass anymore
                    // Both false: there is an optimal numOfObstaclesPassed
                    if (numOfObstaclesPassed >= visited[x,y] || numOfObstaclesPassed > k)
                        continue;
                    
                    visited[x,y] = numOfObstaclesPassed;
                    q.Enqueue(new int[]{x, y, numOfObstaclesPassed});
                }
            }
            
            // move forward
            steps++;
        }
        
        return -1;
    }
}