public class Solution
{
    public int FindCenter(int[][] edges)
    {
        // The graph is valid so we only need to compare first two edges.
        return edges[0][0] == edges[1][0] || edges[0][0] == edges[1][1] ?
            edges[0][0] : edges[0][1];
    }

    public int BruteForce(int[][] edges)
    {
        var adj = new Dictionary<int, List<int>>();

        foreach (var edge in edges)
        {
            if (!adj.ContainsKey(edge[0]))
                adj.Add(edge[0], new List<int>());

            if (!adj.ContainsKey(edge[1]))
                adj.Add(edge[1], new List<int>());

            adj[edge[0]].Add(edge[1]);
            adj[edge[1]].Add(edge[0]);
        }

        foreach (var kvp in adj)
        {
            if (kvp.Value.Count == edges.Length)
                return kvp.Key;
        }

        return 0;
    }
}