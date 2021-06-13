public class Solution {
    public int LargestMagicSquare(int[][] grid) {
        int rows = grid.Length;
        int cols = grid[0].Length;
        
        for (int len = Math.Min(rows, cols); len >= 2; len--)
        {
            for (int row = 0; row + len - 1 < rows; row++)
            {
                for (int col = 0; col + len - 1 < cols; col++)
                {
                    // Check Diagonal sum first
                    long diaSum1 = 0;
                    long diaSum2 = 0;
                    for (int i = 0; i < len; i++)
                    {
                        diaSum1 += grid[row + i][col + i];
                        diaSum2 += grid[row + i][col + len - i - 1];
                    }
                    
                    if (diaSum1 != diaSum2)
                        continue;
                    
                    bool valid = true;
                    
                    for (int i = 0; i < len; i++)
                    {
                        long sum = 0;
                        
                        // check row
                        for (int j = 0; j < len; j++)
                            sum += grid[row + i][col + j];
                        
                        if (sum != diaSum1)
                        {
                            valid = false;
                            break;
                        }
                        
                        sum = 0;
                        
                        // check col
                        for (int j = 0; j < len; j++)
                            sum += grid[row + j][col + i];
                        
                        if (sum != diaSum1)
                        {
                            valid = false;
                            break;
                        }
                    }
                    
                    if (valid)
                        return len;;
                }
            }
        }
        
        return 1;
    }
}