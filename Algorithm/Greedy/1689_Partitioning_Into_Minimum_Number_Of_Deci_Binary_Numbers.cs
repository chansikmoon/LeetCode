public class Solution
{
    public int MinPartitions(string n)
    {
        int ret = 0;

        for (int i = 0; i < n.Length; i++)
        {
            ret = Math.Max(ret, n[i] - '0');
        }

        return ret;
    }
}