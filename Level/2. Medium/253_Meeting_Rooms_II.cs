public class Solution {
    public int MinMeetingRooms(int[][] intervals) {
        int n = intervals.Length;
        int[] start = new int[n], end = new int[n];
        
        for (int i = 0; i < n; i++)
        {
            start[i] = intervals[i][0];
            end[i] = intervals[i][1];
        }
        
        Array.Sort(start);
        Array.Sort(end);
        
        int ret = 0;
        
        for (int s = 0, e = 0; s < n; s++)
        {
            if (start[s] < end[e])
                ret++;
            else
                e++;
        }
        
        return ret;
    }
}