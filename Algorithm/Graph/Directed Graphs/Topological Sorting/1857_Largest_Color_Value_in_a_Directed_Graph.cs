public class Solution
{
    public int LargestPathValue(string colors, int[][] edges)
    {
        int n = colors.Length;
        var adjList = new List<int>[n];
        var indegree = new int[n];

        for (int i = 0; i < n; i++)
            adjList[i] = new List<int>();

        foreach (var edge in edges)
        {
            int u = edge[0], v = edge[1];
            indegree[v]++;
            adjList[u].Add(v);
        }

        var q = new Queue<int>();
        var dp = new int[n, 26];
        for (int i = 0; i < n; i++)
        {
            if (indegree[i] == 0)
            {
                q.Enqueue(i);
                dp[i, colors[i] - 'a'] = 1;
            }
        }

        var max = 0;
        var visited = new bool[n];
        while (q.Count > 0)
        {
            var u = q.Dequeue();

            if (visited[u])
                return -1;

            int tmp = 0;
            for (int i = 0; i < 26; i++)
                tmp = Math.Max(tmp, dp[u, i]);

            max = Math.Max(max, tmp);
            visited[u] = true;

            foreach (int v in adjList[u])
            {
                for (int i = 0; i < 26; i++)
                    dp[v, i] = Math.Max(dp[v, i], dp[u, i] + (colors[v] - 'a' == i ? 1 : 0));

                if (--indegree[v] == 0)
                    q.Enqueue(v);
            }
        }

        return visited.Any(x => x == false) ? -1 : max;
    }
}