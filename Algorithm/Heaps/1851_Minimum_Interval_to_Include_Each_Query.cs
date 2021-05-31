public class Solution
{
    public int[] MinInterval(int[][] intervals, int[] queries)
    {
        var sortedSet = new SortedSet<(int size, int r)>();
        var its = intervals.OrderBy(x => x[0]).ToArray();
        var qs = queries.OrderBy(x => x).ToArray();
        var map = new Dictionary<int, int>();
        int i = 0, n = its.Length;

        foreach (var q in qs)
        {
            while (i < n && its[i][0] <= q)
            {
                int l = its[i][0], r = its[i][1];
                sortedSet.Add((r - l + 1, r));
                i++;
            }

            while (sortedSet.Count > 0 && sortedSet.Min.r < q)
                sortedSet.Remove(sortedSet.Min);

            if (!map.ContainsKey(q))
                map.Add(q, -1);

            if (sortedSet.Count > 0)
                map[q] = sortedSet.Min.size;
        }

        var ret = new int[queries.Length];
        i = 0;

        foreach (var q in queries)
            ret[i++] = map[q];

        return ret;
    }
}