public class Solution {
    public IList<IList<int>> RemoveInterval(int[][] intervals, int[] toBeRemoved) {
        List<IList<int>> ret = new List<IList<int>>();
        
        int start = toBeRemoved[0], end = toBeRemoved[1];
        
        foreach (var interval in intervals)
        {
            if (interval[1] < start || interval[0] > end)
                ret.Add(interval.ToList());
            else
            {
                if (interval[0] < start) ret.Add(new List<int>() {interval[0], start});
                if (interval[1] > end) ret.Add(new List<int>() {end, interval[1]});
            }
        }
        
        return ret;
    }
}