public class Solution
{
    private int[] Directions = new int[] { -1, 0, 1, 0, -1 };

    public IList<IList<int>> PacificAtlantic(int[][] matrix)
    {
        var ret = new List<IList<int>>();
        if (matrix.Length == 0)
            return ret;

        int n = matrix.Length, m = matrix[0].Length;
        var pacificDP = new bool[n, m];
        var atlanticDP = new bool[n, m];

        for (int i = 0; i < n; i++)
        {
            DFS(matrix, pacificDP, -1, i, 0, n, m);
            DFS(matrix, atlanticDP, -1, i, m - 1, n, m);
        }

        for (int i = 0; i < m; i++)
        {
            DFS(matrix, pacificDP, -1, 0, i, n, m);
            DFS(matrix, atlanticDP, -1, n - 1, i, n, m);
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (pacificDP[i, j] && atlanticDP[i, j])
                    ret.Add(new List<int>() { i, j });
            }
        }

        return ret;
    }

    private void DFS(int[][] matrix, bool[,] dp, int height, int i, int j, int n, int m)
    {
        if (i < 0 || i >= n || j < 0 || j >= m || dp[i, j] || matrix[i][j] < height)
            return;

        dp[i, j] = true;

        for (int dir = 1; dir < Directions.Length; dir++)
        {
            int newI = i + Directions[dir - 1];
            int newJ = j + Directions[dir];

            DFS(matrix, dp, matrix[i][j], newI, newJ, n, m);
        }
    }
}