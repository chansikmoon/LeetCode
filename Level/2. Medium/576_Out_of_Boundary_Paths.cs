public class Solution {
    public int FindPaths(int rows, int cols, int maxMove, int startRow, int startColumn) {
        if (maxMove <= 0)
            return 0;
        
        var dp = new int[rows, cols];
        dp[startRow, startColumn] = 1;
        
        var directions = new int[] { 0, 1, 0, -1, 0 };
        int ret = 0, MOD = 1000000007;
        
        for (int step = 1; step <= maxMove; step++)
        {
            var nextDP = new int[rows, cols];
            
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    for (int dir = 1; dir < directions.Length; dir++)
                    {
                        int nextRow = row + directions[dir - 1];
                        int nextCol = col + directions[dir];
                        
                        if (nextRow < 0 || nextRow >= rows || nextCol < 0 || nextCol >= cols)
                        {
                            ret = (ret + dp[row, col]) % MOD;
                        }
                        else
                        {
                            nextDP[nextRow, nextCol] = (nextDP[nextRow, nextCol] + dp[row, col]) % MOD;
                        }
                    }
                }
            }
            
            dp = nextDP;
        }
        
        return ret;
    }

    public int BruteForce(int m, int n, int maxMove, int startRow, int startColumn) {
        var dp = new int[m, n];
        var directions = new int[] { 0, 1, 0, -1, 0 };
        
        for (int col = 0; col < n; col++)
        {
            dp[0, col] += 1;
            dp[m-1, col] += 1;
        }
        
        for (int row = 0; row < m; row++)
        {
            dp[row, 0] += 1;
            dp[row, n - 1] += 1;
        }

        var q = new Queue<int[]>();
        q.Enqueue(new int[] { startRow, startColumn });
        int ret = 0;
        
        while (q.Count > 0)
        {
            int size = q.Count;
            
            while (size-- > 0)
            {
                var coor = q.Dequeue();
                int x = coor[0];
                int y = coor[1];

                ret += dp[x, y];

                for (int dir = 1; maxMove > 1 && dir < directions.Length; dir++)
                {
                    int nextX = x + directions[dir - 1];
                    int nextY = y + directions[dir];
                    
                    if (nextX < 0 || nextX >= m || nextY < 0 || nextY >= n)
                        continue;
                    
                    q.Enqueue(new int[] { nextX, nextY });
                }
            }
            
            maxMove--;
        }
        
        return ret;
    }
}