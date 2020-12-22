public class Solution {
    public int SmallestRangeII(int[] A, int K) {
        Array.Sort(A);
        int n = A.Length, ret = A[n-1] - A[0];
        
        for (int i = 0; i < n - 1; i++)
        {
            int max = Math.Max(A[i] + K, A[n-1] - K);
            int min = Math.Min(A[0] + K, A[i + 1] - K);
            ret = Math.Min(ret, max - min);
        }
        
        return ret;
    }
}