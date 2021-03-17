public class Solution
{
    public int MaxProfit(int[] p, int f)
    {
        int s1 = 0, s2 = Int32.MinValue;

        for (int i = 0; i < p.Length; i++)
        {
            int tmp = s1;
            s1 = Math.Max(s1, s2 + p[i]);
            s2 = Math.Max(s2, tmp - p[i] - f);
        }

        return s1;
    }
}