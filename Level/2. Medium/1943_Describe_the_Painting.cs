public class Solution {
    public IList<IList<long>> SplitPainting(int[][] segments) {
        var sum = new long[100002];
        var end = new bool[100002];
        
        foreach (var s in segments)
        {
            sum[s[0]] += s[2];
            sum[s[1]] -= s[2];
            
            end[s[0]] = true;
            end[s[1]] = true;
        }
        
        var ret = new List<IList<long>>();
        long begin = 0, currSum = 0;
        
        for (long i = 1; i < sum.Length; i++)
        {
            if (currSum > 0 && end[i])
            {
                ret.Add(new List<long>(){begin, i, currSum});
            }
            begin = end[i] ? i : begin;
            currSum += sum[i];
        }
        
        return ret;
    }
}