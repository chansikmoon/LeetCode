public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        // O(log(n) + log(m)) ==> O(log(nm))
        if (matrix.Length == 0 || matrix[0].Length == 0) return false;
        
        int n = matrix.Length, m = matrix[0].Length;

        // Treat this 2D array as a sorted 1D array.
        // [1,2,3,4][5,6,7,8][9,10,11,12]
        // low = 0, high = 3 * 4 - 1
        int low = 0, high = n * m - 1;

        while (low <= high)
        {
            int mid = low + (high - low) / 2;

            // row = mid / # of columns ==> row index
            // col = mid % # of columns ==> col index 
            int row = mid / m;
            int col = mid % m;

            if (matrix[row][col] == target)
                return true;
            else if (matrix[row][col] < target)
                low = row * m + col + 1;
            else
                high = row * m + col - 1;
        }

        return false;
    }

    // O(log n) + O(log m) == O(log(nm))
    public bool BruteForce(int[][] matrix, int target)
    {
        if (matrix.Length == 0 || matrix[0].Length == 0) return false;
        int n = matrix.Length, m = matrix[0].Length;
        
        int rowLow = 0, rowHigh = n - 1;
        
        while (rowLow <= rowHigh)
        {
            int rowMid = rowLow + (rowHigh - rowLow) / 2;
            
            if (matrix[rowMid][0] <= target && matrix[rowMid][m - 1] >= target)
            {
                rowLow = rowMid;
                break;
            }
            else if (matrix[rowMid][0] < target)
                rowLow = rowMid + 1;
            else
                rowHigh = rowMid - 1;
        }
        
        if (rowLow > rowHigh) return false;
        
        int colLow = 0, colHigh = m - 1;
        
        while (colLow <= colHigh)
        {
            int colMid = colLow + (colHigh - colLow) / 2;
            
            if (matrix[rowLow][colMid] == target)
                return true;
            else if (matrix[rowLow][colMid] < target)
                colLow = colMid + 1;
            else
                colHigh = colMid - 1;
        }
        
        return false;
    }
}