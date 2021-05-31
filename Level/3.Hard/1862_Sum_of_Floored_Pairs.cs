public class Solution
{
    public int SumOfFlooredPairs(int[] nums)
    {
        int MAX = 100000, MOD = 1000000007;
        var count = new int[2 * MAX + 1];
        var sumCount = new int[2 * MAX + 1];

        foreach (var num in nums)
            count[num]++;

        for (int i = 1; i < 2 * MAX + 1; i++)
            sumCount[i] = sumCount[i - 1] + count[i];

        long ret = 0;

        for (int i = 1; i <= MAX; i++)
        {
            if (count[i] > 0)
            {
                for (int j = i; j <= MAX; j += i)
                {
                    int div = j / i;
                    int sumOfRangeCount = sumCount[j + i - 1] - sumCount[j - 1];

                    ret += (long)(div * sumOfRangeCount * count[i]) % MOD;
                    ret %= MOD;
                }
            }
        }

        return (int)ret;
    }
}