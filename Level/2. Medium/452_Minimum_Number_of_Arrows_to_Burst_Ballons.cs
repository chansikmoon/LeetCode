public class Solution {
    public int FindMinArrowShots(int[][] points) {
        int n = points.Length;
        if (n == 0)
            return 0;
        
        Array.Sort(points, (a, b) =>
                   {
                       int ret = a[0].CompareTo(b[0]);
                       return ret == 0 ? a[1].CompareTo(b[1]) : ret;
                   });
        
        int ret = 1, start = points[0][0], end = points[0][1];
        
        for (int i = 1; i < n; i++)
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

/*
1--------------6
    2-------------------8
                   7--------------------12
                                10--------------------------16
                                             
*/