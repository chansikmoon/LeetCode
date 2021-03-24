public class Solution
{
    public int ThreeSumMulti(int[] A, int target)
    {
        var map = new Dictionary<int, int>();

        int res = 0, mod = 1000000007;

        for (int i = 0; i < A.Length; i++)
        {
            int jj = target - A[i];
            int jValue = 0;

            map.TryGetValue(jj, out jValue);

            res = (res + jValue) % mod;

            for (int j = 0; j < i; j++)
            {
                int k = A[i] + A[j];
                int kValue = 0;

                if (!map.ContainsKey(k))
                    map.Add(k, 0);

                map.TryGetValue(k, out kValue);

                map[k] = kValue + 1;
            }
        }

        return res;
    }
}