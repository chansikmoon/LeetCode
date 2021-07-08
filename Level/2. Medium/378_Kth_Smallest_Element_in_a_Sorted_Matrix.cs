public class Solution {
    public int KthSmallest(int[][] matrix, int k) {
        int n = matrix.Length;
        int l = matrix[0][0], r = matrix[n - 1][n - 1];
        
        while (l < r)
        {
            int m = l + (r - l) / 2;
            int count = 0;
            for (int row = 0; row < n; row++)
            {
                int col = n - 1;
                while (col >= 0 && matrix[row][col] > m)
                    col--;
                count += (col + 1);
            }
            
            if (count < k)
                l = m + 1;
            else 
                r = m;
        }
        
        return l;
    }
}