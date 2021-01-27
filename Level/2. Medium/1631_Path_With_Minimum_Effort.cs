public class Solution {
    // My solution was TLE so learned from here: https://leetcode.com/problems/path-with-minimum-effort/discuss/910206/First-practice-C-copy-idea-and-copy-code-to-learn-quickly
    public int MinimumEffortPath(int[][] heights) {
        int[] dirs = new int[] { 0, 1, 0, -1, 0};
        int n = heights.Length, m = heights[0].Length;
        bool[,] visited = new bool[n,m];
        
        var sorted = new SortedSet<(int h, int x, int y)>();
        sorted.Add((0,0,0));
        
        while(sorted.Count > 0)
        {
            var curr = sorted.Min;
            if (curr.x == n-1 && curr.y == m-1)
                return curr.h;
            
            visited[curr.x, curr.y] = true;
            sorted.Remove(curr);
            
            for (int d = 0; d < 4; d++)
            {
                int nextX = curr.x + dirs[d];
                int nextY = curr.y + dirs[d + 1];
                
                if (nextX < 0 || nextX >= n || nextY < 0 || nextY >= m || visited[nextX, nextY])
                    continue;
                
                var nextH = Math.Max(curr.h, Math.Abs(heights[curr.x][curr.y] - heights[nextX][nextY]));
                sorted.Add((nextH, nextX, nextY));
            }
        }
        
        return 0;
    }
}