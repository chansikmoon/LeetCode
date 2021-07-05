public class Solution {
    public int[][] MatrixReshape(int[][] mat, int r, int c) {
        int rows = mat.Length, cols = mat[0].Length;
        
        if (r * c != rows * cols)
            return mat;
        
        var ret = new int[r][];
        for (int i = 0; i < r; i++)
            ret[i] = new int[c];
        
        for (int i = 0; i < rows * cols; i++)
        {
            ret[i/c][i%c] = mat[i/cols][i%cols];
        }
        // for (int row = 0; row < rows; row++)
        // {
        //     for (int col = 0; col < cols; col++)
        //     {
        //         int normalizedIndex = row * cols + col;
        //         int newRow = normalizedIndex / c;
        //         int newCol = normalizedIndex % c;
        //         ret[newRow][newCol] = mat[row][col];
        //     }
        // }
        
        return ret;
    }
}
