public class Solution {
    public int FindMinArrowShots(int[][] arr) {
        if (arr.Length == 0) return 0;
        
        var points = arr.OrderBy(x => x[0]).ThenBy(x => x[1]).ToArray();;
        
        int ret = 1, start = points[0][0], end = points[0][1];
        
        for (int i = 1; i < points.Length; i++)
        {
            if (start < points[i][0] && end < points[i][0])
            {
                ret++;
                start = points[i][0];
                end = points[i][1];
            }
            else
            {
                start = Math.Max(start, points[i][0]);
                end = Math.Min(end, points[i][1]);
            }
        }
        
        return ret;
    }
}