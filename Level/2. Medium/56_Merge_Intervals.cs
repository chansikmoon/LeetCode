public class Solution {
    public int[][] Merge(int[][] intervals) {
        Array.Sort(intervals, (a ,b) => a[0] - b[0]);
        
        List<int[]> ret = new List<int[]>();
        
        ret.Add(intervals[0]);
        
        for (int i = 1; i < intervals.Length; i++)
        {
            var last = ret.Last();
            
            if (last[0] <= intervals[i][0] && last[1] >= intervals[i][1])
                continue;
            else if (last[1] >= intervals[i][0])
                last[1] = intervals[i][1];
            else
                ret.Add(intervals[i]);
        }
        
        return ret.ToArray();
    }
}