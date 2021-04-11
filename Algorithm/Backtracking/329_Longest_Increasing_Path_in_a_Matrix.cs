public class Solution
{
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