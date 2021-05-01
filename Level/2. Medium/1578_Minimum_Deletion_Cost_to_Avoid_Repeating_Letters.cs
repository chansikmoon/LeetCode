public class Solution
{
    // TC: O(n)
    // SC: O(1)
    public int MinCost(string s, int[] cost)
    {
        int ret = 0, sum = 0, max = 0;

        for (int i = 0; i < cost.Length; i++)
        {
            if (i > 0 && s[i] != s[i - 1])
            {
                // if there is one character, then sum - max will zero out.
                ret += sum - max;
                sum = max = 0;
            }

            sum += cost[i];
            max = Math.Max(max, cost[i]);
        }

        ret += sum - max;

        return ret;
    }
    public int BruteForce(string s, int[] cost)
    {
        int ret = 0, sum = cost[0], max = cost[0];

        for (int l = 0, r = 1; r < s.Length; r++)
        {
            if (s[l] != s[r])
            {
                l = r;
                sum = cost[l];
                max = cost[l];

                continue;
            }

            max = Math.Max(cost[r], max);
            sum += cost[r];

            while (r + 1 < s.Length && s[r] == s[r + 1])
            {
                r++;
                max = Math.Max(cost[r], max);
                sum += cost[r];
            }

            ret += sum - max;
        }

        return ret;
    }
}