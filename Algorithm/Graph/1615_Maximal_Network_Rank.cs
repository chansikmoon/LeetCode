public class Solution
{
    public int MaximalNetworkRank(int n, int[][] roads)
    {
        var connection = new bool[n, n];
        var count = new int[n];

        foreach (var road in roads)
        {
            count[road[0]]++;
            count[road[1]]++;
            connection[road[0], road[1]] = true;
            connection[road[1], road[0]] = true;
        }

        int ret = 0;

        for (int i = 0; i < n - 1; i++)
        {
            for (int j = i + 1; j < n; j++)
                ret = Math.Max(ret, count[i] + count[j] - (connection[i, j] ? 1 : 0));
        }

        return ret;
    }
}