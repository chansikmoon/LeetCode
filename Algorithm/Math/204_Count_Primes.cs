public class Solution
{
    public int CountPrimes(int n)
    {
        var arr = new bool[n];

        for (int i = 2; i <= (int)Math.Sqrt(n); i++)
        {
            if (!arr[i])
            {
                for (int j = i * i; j < n; j += i)
                    arr[j] = true;
            }
        }

        int ret = 0;
        for (int i = 2; i < n; i++)
        {
            if (!arr[i])
                ret++;
        }

        return ret;
    }
}