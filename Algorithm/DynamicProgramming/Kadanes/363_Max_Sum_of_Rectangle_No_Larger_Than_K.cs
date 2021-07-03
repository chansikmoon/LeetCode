public class Solution {
    public int MaxSumSubmatrix(int[][] matrix, int k) {
        int ret = Int32.MinValue;
        int rows = matrix.Length, cols = matrix[0].Length;
        
        // m * m * (n + n * n) => O(cols ^ 2 * rows ^ 2)
        // m
        for (int left = 0; left < cols; left++)
        {
            var dp = new int[rows];
            
            // m
            for (int right = left; right < cols; right++)
            {
                int currMax = 0, max = Int32.MinValue;
                
                // n
                for (int row = 0; row < rows; row++)
                {
                    dp[row] += matrix[row][right];
                    currMax = Math.Max(dp[row], currMax + dp[row]);
                    max = Math.Max(max, currMax);
                }
                
                if (max <= k)
                    ret = Math.Max(ret, max);
                
                // n
                for (int top = 0; top < rows; top++)
                {
                    int sum = 0;
                    
                    // n
                    for (int row = top; row < rows; row++)
                    {
                        sum += dp[row];
                        if (sum <= k)
                            ret = Math.Max(ret, sum);
                    }
                }
            }
        }
        
        return ret;
    }
}