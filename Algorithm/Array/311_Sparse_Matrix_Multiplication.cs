public class Solution {
    public int[][] Multiply(int[][] mat1, int[][] mat2) {
        int m = mat1.Length, K = mat1[0].Length, n = mat2[0].Length;
        var ret = new int[m][];
        
        for (int i = 0; i < m; i++)
        {
            ret[i] = new int[n];
            
            for (int j = 0; j < n; j++)
                for (int k = 0; k < K; k++)
                    ret[i][j] += mat1[i][k] * mat2[k][j];
        }
        
        return ret;
    }

    public int[][] Faster(int[][] mat1, int[][] mat2) {
        int m = mat1.Length, K = mat1[0].Length, n = mat2[0].Length;
        var ret = new int[m][];
        
        for (int i = 0; i < m; i++)
        {
            ret[i] = new int[n];
            
            for (int k = 0; k < K; k++)
            {
                if (mat1[i][k] == 0) continue;
                
                for (int j = 0; j < n; j++)
                {
                    if (mat2[k][j] == 0) continue;
                    ret[i][j] += mat1[i][k] * mat2[k][j];
                }
            }
        }
        
        return ret;
    }
}