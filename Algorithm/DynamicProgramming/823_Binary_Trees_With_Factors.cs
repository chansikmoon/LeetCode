public class Solution
{
    public int NumFactoredBinaryTrees(int[] arr)
    {
        long ret = 0, mod = 1000000007;
        Array.Sort(arr);
        var dp = new Dictionary<int, long>();

        for (int i = 0; i < arr.Length; i++)
        {
            dp.Add(arr[i], 1);

            for (int j = 0; j < i; j++)
            {
                if (arr[i] % arr[j] == 0)
                {
                    long jValue = 0, iDivideByj = 0;
                    dp.TryGetValue(arr[j], out jValue);
                    dp.TryGetValue(arr[i] / arr[j], out iDivideByj);
                    dp[arr[i]] = (dp[arr[i]] + jValue * iDivideByj) % mod;
                }
            }

            ret = (ret + dp[arr[i]]) % mod;
        }

        return (int)ret;
    }
}