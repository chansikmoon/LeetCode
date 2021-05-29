public class Solution
{
    public int ConnectSticks(int[] sticks)
    {
        var pq = new SortedSet<(int cost, int index)>();

        // O(n log n)
        for (int i = 0; i < sticks.Length; i++)
            pq.Add((sticks[i], i));

        int ret = 0;

        // O(n) => O(n log n)
        while (pq.Count > 1)
        {
            // O(log n)
            var a = pq.Min;
            pq.Remove(a);
            // O(log n)
            var b = pq.Min;
            pq.Remove(b);

            ret += a.cost + b.cost;
            // O(log n)
            pq.Add((a.cost + b.cost, a.index));
        }

        return ret;
    }
}