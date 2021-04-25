public class Solution
{
    public int SumBase(int n, int k)
    {
        int ret = 0;

        while (n >= k)
        {
            ret += n % k;
            n /= k;
        }

        return ret + n;
    }
}