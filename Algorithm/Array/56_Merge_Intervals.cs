public class Solution {
    public int[][] Merge(int[][] intervals) {
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
        var ret = new List<int[]>();
        ret.Add(intervals[0]);
        
        for (int i = 1; i < intervals.Length; i++)
        {
            if (intervals[i][0] <= ret.Last()[1])
                ret.Last()[1] = Math.Max(ret.Last()[1], intervals[i][1]);
            else
                ret.Add(intervals[i]);
        }
        
        return ret.ToArray();
    }
}