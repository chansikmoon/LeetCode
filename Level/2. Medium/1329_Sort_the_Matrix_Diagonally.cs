public class Solution {
    public int[][] DiagonalSort(int[][] mat) {
        int n = mat.Length, m = mat[0].Length;
        var map = new Dictionary<int, List<int>>();
        
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (!map.ContainsKey(i-j))
                    map.Add(i-j, new List<int>());
                
                map[i-j].Add(mat[i][j]);
            }
        }
        
        for (int i = -(m-1); i < n; i++)
            map[i].Sort();
        
        for (int i = n - 1; i >= 0; i--)
        {
            for (int j = m - 1; j >= 0; j--)
            {
                mat[i][j] = map[i-j].Last();
                map[i-j].RemoveAt(map[i-j].Count - 1);
            }
        }
        
        return mat;
    }

    private int[][] BruteForce(int[][] mat)
    {
        int n = mat.Length, m = mat[0].Length;
        var ret = new int[n][];
        for (int i = 0; i < n; i++)
            ret[i] = new int[m];
        
        for (int i = n - 1; i >= 0; i--)
            SetSortedListIntoMatrix(mat, ret, i, 0);
        
        for (int j = m - 1; j >= 0; j--)
            SetSortedListIntoMatrix(mat, ret, 0, j);
        
        return ret;
    }
    
    private void SetSortedListIntoMatrix(int[][] mat, int[][] ret, int i, int j)
    {
        var list = GetSortedList(mat, i, j);
        
        foreach (int num in list)
            ret[i++][j++] = num;
    }
    
    private List<int> GetSortedList(int[][] mat, int i, int j)
    {
        var list = ToSingleList(mat, i, j);
        
        return list.OrderBy(x => x).ToList();
    }
    
    private List<int> ToSingleList(int[][] mat, int i, int j)
    {
        int n = mat.Length, m = mat[0].Length;
        
        var ret = new List<int>();
        
        while (i < n && j < m)
            ret.Add(mat[i++][j++]);
        
        return ret;
    }
}