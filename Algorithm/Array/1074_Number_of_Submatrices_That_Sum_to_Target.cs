public class Solution {
    public int NumSubmatrixSumTarget(int[][] matrix, int target) {
        int n = matrix.Length, m = matrix[0].Length;
        
        for (int i = 0; i < n; i++)
        {
            for (int j = 1; j < m; j++)
                matrix[i][j] += matrix[i][j-1];
        }
        
        int ret = 0;
        var map = new Dictionary<int, int>();
        for (int l = 0; l < m; l++)
        {
            for (int r = l; r < m; r++)
            {
                map.Clear();
                map.Add(0, 1);
                int curr = 0;
                
                for (int row = 0; row < n; row++)
                {
                    curr += matrix[row][r] - (l > 0 ? matrix[row][l-1] : 0);
                    if (map.ContainsKey(curr - target))
                        ret += map[curr - target];
                    if (!map.ContainsKey(curr))
                        map.Add(curr, 0);
                    map[curr]++;
                }
            }
        }
        
        return ret;
    }
}