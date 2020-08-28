public class Solution {
    public int[] FindRightInterval(int[][] intervals) {
        int n = intervals.Length;
        int[][] startAndIndex = new int[n][];
        int[] ret = new int[n];
        
        for (int i = 0; i < n; i++)
            startAndIndex[i] = new int[] {intervals[i][0], i};
        
        var sorted = startAndIndex.OrderBy(x => x[0]).ToArray();
        
        for (int i = 0; i < n; i++)
        {
            int l = 0, r = n - 1;
            
            while (l < r)
            {
                int m = l + (r - l) / 2;
                if (sorted[m][0] >= intervals[i][1])
                    r = m ;
                else
                    l = m + 1;
            }
            
            ret[i] = sorted[l][0] >= intervals[i][1] ? sorted[l][1] : -1;
        }
        
        return ret.ToArray();
    }

    public int[] AnotherSolution(int[][] intervals)
    {
        int n = intervals.Length, maxRight = Int32.MinValue;
        int[] ret = new int[n];
        Dictionary<int, int> map = new Dictionary<int, int>();
        
        for (int i = 0; i < n; i++)
        {
            map.Add(intervals[i][0], i);
            maxRight = Math.Max(maxRight, intervals[i][1]);
        }
        
        for (int i = 0; i < n; i++)
        {
            int j = intervals[i][1];
            while (!map.ContainsKey(j) && j <= maxRight)
                j++;
            
            ret[i] = j <= maxRight ? map[j] : -1;
        }
        
        return ret;
    }
}