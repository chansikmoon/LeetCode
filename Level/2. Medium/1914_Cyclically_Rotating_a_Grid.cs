public class Solution {
    public int[][] RotateGrid(int[][] grid, int K) {
        int rows = grid.Length, cols = grid[0].Length;
                
        for (int depth = 0; depth < Math.Min(cols / 2, rows / 2); depth++)
        {
            int oneCycle = (rows - depth * 2) * 2 + (cols - depth * 2) * 2 - 4;
            
            for (int k = 0; k < K % oneCycle; k++)
            {
                Rotate(grid, depth, depth, rows - depth, cols - depth);
            }
        }
        
        return grid;
    }
    
    private void Rotate(int[][] grid, int row, int col, int rows, int cols)
    {
        int startingRow = row, startingCol = col;
        
        int prev = grid[row][col];
        
        for (; col < cols - 1; col++)
            grid[row][col] = grid[row][col + 1];
        
        for (; row < rows - 1; row ++)
            grid[row][col] = grid[row + 1][col];
        
        for (; col > startingCol; col--)
            grid[row][col] = grid[row][col -1];
        
        for (; row > startingRow; row--)
            grid[row][col] = grid[row - 1][col];
        
        grid[row + 1][col] = prev;
    }
}