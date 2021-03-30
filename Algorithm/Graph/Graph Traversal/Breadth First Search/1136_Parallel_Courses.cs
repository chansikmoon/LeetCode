public class Solution
{
    public int MinimumSemesters(int n, int[][] relations)
    {
        var nei = new HashSet<int>[n];
        var indegree = new int[n];

        for (int i = 0; i < n; i++)
            nei[i] = new HashSet<int>();


        foreach (var r in relations)
        {
            int pre = r[0];
            int next = r[1];

            nei[pre - 1].Add(next - 1);
            indegree[next - 1]++;
        }

        int ret = 0;
        var q = new Queue<int>();

        for (int i = 0; i < n; i++)
            if (indegree[i] == 0)
                q.Enqueue(i);

        while (q.Count > 0)
        {
            int size = q.Count;

            while (size-- > 0)
            {
                int curr = q.Dequeue();

                foreach (int next in nei[curr])
                {
                    if (--indegree[next] == 0)
                        q.Enqueue(next);
                }

            }

            ret++;
        }

        return indegree.Max() > 0 ? -1 : ret;
    }
}