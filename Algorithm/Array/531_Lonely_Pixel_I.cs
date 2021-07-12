public class Solution {
    public int FindLonelyPixel(char[][] p) {
        int m = p.Length, n = p[0].Length;
        var rows = new int[m];
        var cols = new int[n];
        
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (p[i][j] == 'B')
                {
                    rows[i]++;
                    cols[j]++;
                }
            }
        }
        
        int ret = 0;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (p[i][j] == 'B' && rows[i] == 1 && cols[j] == 1)
                    ret++;
            }
        }
        
        return ret;
    }
}