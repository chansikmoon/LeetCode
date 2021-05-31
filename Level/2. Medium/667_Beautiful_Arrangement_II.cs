public class Solution
{
    public int[] ConstructArray(int n, int k)
    {
        var ret = new int[n];
        int l = 1, r = n;

        for (int i = 0; i < n; i++)
        {
            ret[i] = k % 2 != 0 ? l++ : r--;
            if (k > 1)
                k--;
        }

        return ret.ToArray();
    }
}