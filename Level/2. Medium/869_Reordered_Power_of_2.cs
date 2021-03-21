public class Solution
{
    public bool ReorderedPowerOf2(int N)
    {
        int c = helper(N);
        for (int i = 0; i < 32; i++)
        {
            if (helper(1 << i) == c)
                return true;
        }

        return false;
    }

    private int helper(int i)
    {
        int ret = 0;
        for (; i > 0; i /= 10)
            ret += (int)Math.Pow(10, i % 10);
        return ret;
    }
}