public class Solution
{
    public int MaxEnvelopes(int[][] envelopes)
    {
        int n = envelopes.Length;
        var ret = new List<int>();
        var sorted = envelopes.OrderBy(x => x[0]).ThenByDescending(x => x[1]).ToArray();

        for (int i = 0; i < n; i++)
        {
            int l = 0, r = ret.Count - 1;
            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                if (sorted[i][1] > sorted[ret[mid]][1])
                    l = mid + 1;
                else
                    r = mid - 1;
            }
            if (l == ret.Count)
                ret.Add(i);
            else
                ret[l] = i;
        }

        return ret.Count;
    }

    private int BruteForce(int[][] enve)
    {
        var env = enve.OrderBy(x => x[0]).ThenBy(x => x[1]).ToList();

        var map = new Dictionary<int[], List<int[]>>();
        var indegree = new int[enve.Length];

        for (int i = 0; i < enve.Length; i++)
        {
            if (!map.ContainsKey(env[i]))
                map.Add(env[i], new List<int[]>());

            for (int j = 0; j < enve.Length; j++)
            {
                if (i == j)
                    continue;

                if (env[j][0] > env[i][0] && env[j][1] > env[i][1])
                {
                    map[env[i]].Add(env[j]);
                    indegree[j]++;
                }
            }
        }

        int ret = 0;
        var q = new Queue<int[]>();
        for (int i = 0; i < enve.Length; i++)
        {
            if (indegree[i] == 0)
                q.Enqueue(env[i]);
        }

        while (q.Count > 0)
        {
            int size = q.Count;

            while (size-- > 0)
            {
                var curr = q.Dequeue();
                // Console.WriteLine(string.Format("curr: {0} {1}", curr[0], curr[1]));
                foreach (var next in map[curr])
                {
                    // Console.WriteLine(string.Format("next: {0} {1}", next[0], next[1]));
                    q.Enqueue(next);
                }
            }

            ret++;
        }

        return ret;
    }
}