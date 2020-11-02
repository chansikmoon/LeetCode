public class Solution {
    public bool CanAttendMeetings(int[][] intervals) {
        Array.Sort(intervals, (x, y) => x[0] - y[0]);
        
        for (int i = 1; i < intervals.Length; i++)
        {
            if (intervals[i - 1][1] > intervals[i][0])
                return false;
        }
        
        return true;
    }
}