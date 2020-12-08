public class Solution {
    public int[][] GenerateMatrix(int n) {
        int[][] ret = new int[n][];
        for (int i = 0; i < n; i++)
            ret[i] = new int[n];
        
        int r = 0, c = 0, rowInc = 0, colInc = 1;
        
        for (int i = 0; i < n * n; i++)
        {
            ret[r][c] = i + 1;
            
            // To turn right
            if (ret[(r + rowInc + n) % n][(c + colInc + n) % n] > 0)
            {
                int tmp = rowInc;
                rowInc = colInc;
                colInc = -tmp;
            }
            
            r += rowInc;
            c += colInc;
        }
        
        return ret;
    }
}