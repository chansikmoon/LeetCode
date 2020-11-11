public class Solution {
    public int[][] FlipAndInvertImage(int[][] A) {
        if (A.Length == 0 || A[0].Length == 0) return A;
        
        int n = A.Length, m = A[0].Length;
        
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col * 2 < m; col++)
            {
                int temp = A[row][col];
                A[row][col] = A[row][m - col - 1] ^ 1;
                A[row][m - col - 1] = temp ^ 1;
            }
        }
        
        return A;
    }
}