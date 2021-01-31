public class Solution {
    public bool[] CanEat(int[] candiesCount, int[][] queries) {
        var preSum = new long[candiesCount.Length + 1];
        
        for (int i = 1; i <= candiesCount.Length; i++)
            preSum[i] = preSum[i-1] + candiesCount[i-1];
        
        var ret = new List<bool>();
        foreach (var q in queries)
        {
            long min = q[1] + 1;
            long max = min * q[2];
            ret.Add(preSum[q[0]] < max && min <= preSum[q[0] + 1]);
        }
        
        return ret.ToArray();
    }
}