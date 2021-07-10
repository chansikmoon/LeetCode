public class Solution {
    public int NearestExit(char[][] maze, int[] e) {
        var dir = new int[] { 0, -1, 0, 1, 0 };
        int rows = maze.Length, cols = maze[0].Length;
        
        var visited = new bool[rows, cols];
        var q = new Queue<(int x, int y, int z)>();
        
        q.Enqueue((e[0], e[1], 0));
        
        while (q.Count > 0)
        {
            var curr = q.Dequeue();
            if (visited[curr.x, curr.y])
                continue;
            
            visited[curr.x, curr.y] = true;
            
            if (curr.z > 0 && (curr.x == 0 || curr.x == rows - 1 || curr.y == 0 || curr.y == cols - 1))
                return curr.z;
            
            for (int d = 1; d < 5; d++)
            {
                int nextX = curr.x + dir[d - 1];
                int nextY = curr.y + dir[d];
                
                if (nextX < 0 || nextX >= rows || nextY < 0 || nextY >= cols || maze[nextX][nextY] == '+')
                    continue;
                
                q.Enqueue((nextX, nextY, curr.z + 1));
            }
        }
        
        return -1;
    }
}