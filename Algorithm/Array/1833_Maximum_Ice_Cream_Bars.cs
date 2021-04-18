public class Solution
{
    public int MaxIceCream(int[] costs, int coins)
    {
        Array.Sort(costs);
        int ret = 0;
        for (int i = 0; i < costs.Length; i++)
        {
            if (coins >= costs[i])
            {
                ret++;
                coins -= costs[i];
            }
        }

        return ret;
    }
}