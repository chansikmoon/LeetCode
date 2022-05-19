public class Solution
{
    // Revisited 05/19/2022 BFS approach
    public int LongestIncreasingPathBFS(int[][] matrix) {
        int m = matrix.Length;
        int n = matrix[0].Length;
        
        var dirs = new int[] { 0, 1, 0, -1, 0 };
        var indegree = new int[m,n];
        
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                for (int d = 1; d < dirs.Length; d++) {
                    int nextI = i + dirs[d - 1];
                    int nextJ = j + dirs[d];
                    
                    if (nextI < 0 || nextI >= m || nextJ < 0 || nextJ >= n ||
                       matrix[i][j] <= matrix[nextI][nextJ]) {
                        continue;
                    }
                    
                    // matrix[nextI][nextJ] -> matrix[i][j]
                    indegree[i,j]++;
                }
            }
        }
        
        var q = new Queue<(int x, int y)>();
        
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (indegree[i,j] == 0) {
                    q.Enqueue((i, j));
                }                    
            }
        }
        
        int ret = 0;
        
        while (q.Count > 0) {            
            int count = q.Count;
            
            while (count-- > 0) {
                var coor = q.Dequeue();
                int row = coor.x;
                int col = coor.y;

                for (int d = 1; d < dirs.Length; d++) {
                    int nextRow = row + dirs[d - 1];
                    int nextCol = col + dirs[d];

                    // matrix[nextRow][nextCol] must be greater than matrix[row][col]
                    if (nextRow < 0 || nextRow >= m || nextCol < 0 || nextCol >= n ||
                       matrix[row][col] >= matrix[nextRow][nextCol]) {
                        continue;
                    }

                    if (--indegree[nextRow, nextCol] == 0) {
                        q.Enqueue((nextRow, nextCol));
                    }
                }
            }
            
            ret++;
        }
        
        return ret;
    }

    private int[] DIRS = new int[] { 0, 1, 0, -1, 0 };

    public int LongestIncreasingPath(int[][] matrix)
    {
        int ret = 0, n = matrix.Length, m = matrix[0].Length;
        var dp = new int[n, m];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                ret = Math.Max(ret, DFS(matrix, dp, i, j, -1));
            }
        }

        return ret;
    }

    private int DFS(int[][] matrix, int[,] visited, int i, int j, int prevVal)
    {
        if (i < 0 || i >= matrix.Length || j < 0 || j >= matrix[0].Length ||
            matrix[i][j] <= prevVal)
            return 0;

        if (visited[i, j] != 0)
            return visited[i, j];

        int ret = 0;

        for (int d = 1; d < DIRS.Length; d++)
        {
            ret = Math.Max(ret, DFS(matrix, visited, i + DIRS[d - 1], j + DIRS[d], matrix[i][j]) + 1);
        }

        visited[i, j] = ret;

        return ret;
    }
}