public class Solution {
    public int[][] IntervalIntersection(int[][] f, int[][] s) {
        var ret = new List<int[]>();
        
        if (f.Length == 0 || s.Length == 0)
            return ret.ToArray();
        
        int i = 0, j = 0;
        
        while (i < f.Length && j < s.Length)
        {
            int start = Math.Max(f[i][0], s[j][0]);
            int end = Math.Min(f[i][1], s[j][1]);
            
            if (start <= end)
                ret.Add(new int[] { start, end });
            
            if (f[i][1] < s[j][1])
                i++;
            else
                j++;
        }
        
        return ret.ToArray();
    }
}