public class Solution {
    public int[] MinDifference(int[] nums, int[][] queries) {
        int n = nums.Length;
        var preSum = new int[n + 1, 101];
        var count = new int[101];
        
        for (int i = 0; i < n; i++)
        {
            count[nums[i]]++;
            
            for (int j = 1; j < 101; j++)
                preSum[i + 1, j] = count[j];
        }
        
        var ret = new int[queries.Length];
        
        for (int i = 0; i < queries.Length; i++)
        {
            int L = queries[i][0], R = queries[i][1];
            count = new int[101];
            
            for (int j = 1; j < 101; j++)
                count[j] = preSum[R + 1, j] - preSum[L, j];
            
            int prev = -1, min = Int32.MaxValue;
            
            for (int j = 1; j < 101; j++)
            {
                if (count[j] == 0)
                    continue;
                if (prev != -1 && j - prev < min)
                    min = j - prev;
                prev = j;
            }
            
            ret[i] = min == Int32.MaxValue ? -1 : min;
        }
        
        return ret;
    }
}