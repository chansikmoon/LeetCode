public class Solution {
    public int RemoveCoveredIntervals(int[][] intervals) {
        Array.Sort(intervals, (a, b) => a[0] - b[0]);
        int ret = 0, left = -1, right = -1;
        foreach (var i in intervals) {
            if (i[0] > left && i[1] > right) {
                left = i[0];
                ret++;
            }
            
            right = Math.Max(right, i[1]);
        }
        
        return ret;
    }
}