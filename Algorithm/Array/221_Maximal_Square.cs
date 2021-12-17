public class Solution {
    public int MaximalSquare(char[][] matrix) {
        int rows = matrix.Length, cols = matrix[0].Length, max = 0;
        var dp = new int[rows + 1, cols + 1];
        
        for (int row = 1; row <= rows; row++)
        {
            for (int col = 1; col <= cols; col++)
            {
                if (matrix[row-1][col-1] == '1')
                {
                    dp[row, col] = Math.Min(dp[row-1,col-1], Math.Min(dp[row-1,col], dp[row, col-1])) + 1;
                    max = Math.Max(max, dp[row, col]);
                }
            }
        }
        
        return max * max;
    }
}