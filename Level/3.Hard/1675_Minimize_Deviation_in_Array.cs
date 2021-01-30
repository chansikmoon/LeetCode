public class Solution {
    public int MinimumDeviation(int[] nums) {
        var sortedSet = new SortedSet<int>();
        foreach (int n in nums)
            sortedSet.Add(n % 2 == 1 ? n * 2 : n);
        
        int ret = sortedSet.Max - sortedSet.Min;
        
        while (sortedSet.Max % 2 == 0)
        {
            int max = sortedSet.Max;
            sortedSet.Remove(max);
            sortedSet.Add(max / 2);
            
            ret = Math.Min(ret, sortedSet.Max - sortedSet.Min);
        }
        
        return ret;
    }
}