public class Solution {
    public int[] NumsSameConsecDiff(int N, int K) {
        if (N == 1) return new int[] {0,1,2,3,4,5,6,7,8,9};
        
        List<int> ret = new List<int>();
        
        for (int i = 1; i < 10; i++)
            DFS(ret, i, N - 1, K);
        
        return ret.ToArray();
    }
    
    // Time: O(N * 2^N), N is the number of digits
    //      - Invoke the recursive function N times.
    //      - Total 9 * 2 ^ N-1 number of potential combinations ==> O(N * 2^N)
    //      - when K = 0, it would have 9 difference numbers ==> O(N)
    // Space: O(2^N)
    private void DFS(List<int> ret, int num, int n, int k)
    {
        if (n == 0)
        {
            ret.Add(num);
            return;
        }
            
        int digit = num % 10;
        if (digit + k < 10)
            DFS(ret, num * 10 + digit + k, n - 1, k);
        if (k > 0 && digit - k >= 0)
            DFS(ret, num * 10 + digit - k, n - 1, k);    
    }

    // Solution from lee215
    // If K >= 5, Time and space O(N)
    // If K <= 4, Time and space O(2^N)
    private int[] Solution1(int N, int K)
    {
        List<int> ret = new List<int>() {0,1,2,3,4,5,6,7,8,9};

        for (int n = 2; n <= N; n++)
        {
            List<int> tmpList = new List<int>();
            foreach (int d in ret)
            {
                int digit = d % 10;

                if (d > 0 && digit + K < 10)
                    tmpList.Add(d * 10 + digit + K);
                if (d > 0 && K > 0 && digit - K >= 0)
                    tmpList.Add(d * 10 + digit - K);
            }

            ret = tmpList;
        }

        return ret.ToArray();
    }
}
