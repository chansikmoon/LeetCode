public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        int i = 0, j = matrix[0].Length - 1, n = matrix.Length, m = matrix[0].Length;
        
        while (ValidRange(i, j, n, m))
        {
            if (matrix[i][j] == target)
                return true;
            
            int currVal = matrix[i][j];
            
            if (currVal > target)
                j--;
            else
                i++;
        }
        
        return false;
    }
    
    private bool ValidRange(int i, int j, int n, int m)
    {
        return i >= 0 && i < n && j >= 0 && j < m;
    }
}