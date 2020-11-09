public class Solution {
    public int TwoSumLessThanK(int[] A, int K) {
        int ret = -1, i = 0, j = A.Length - 1;
        Array.Sort(A);
        while (i < j)
        {
            if (A[i] + A[j] < K)
            {
                ret = Math.Max(A[i] + A[j], ret);
                i++;
            }
            else
                j--;
        }
        
        return ret;
    }
    
    public int BruteForce(int[] A, int K)
    {
        int ret = -1;
        
        for (int i = 0; i < A.Length - 1; i++)
        {
            for (int j = i + 1; j < A.Length; j++)
            {
                if (A[i] + A[j] < K)
                    ret = Math.Max(ret, A[i] + A[j]);
            }
        }
        
        return ret;
    }
}