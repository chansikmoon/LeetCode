public class Solution {
    public int[][] KClosest(int[][] points, int k) {
        var list = new List<int[]>();
        
        for (int i = 0; i < points.Length; i++)
        {
            int dist = points[i][0] * points[i][0] + points[i][1] * points[i][1];
            list.Add(new int[] { dist, i });
        }
        
        list.Sort((x,y) => x[0].CompareTo(y[0]));
        var retval = new List<int[]>();
        
        for (int i = 0; i < k; i++)
        {
            var point = points[list[i][1]];
            retval.Add(new int[]{ point[0], point[1] });
        }
        
        return retval.ToArray();
    }
}