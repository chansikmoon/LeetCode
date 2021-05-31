public class Solution
{
    private int[] MinVisitedTime = null;
    private int[] Visited = null;
    private int[] Parent = null;
    private int time = 0;

    public IList<IList<int>> CriticalConnections(int n, IList<IList<int>> connections)
    {
        var ret = new List<IList<int>>();
        var adjList = GetAdjList(n, connections);

        MinVisitedTime = GetNSizeArray(n, -1);
        Visited = GetNSizeArray(n, -1);
        Parent = GetNSizeArray(n, -1);

        for (int i = 0; i < n; i++)
        {
            if (Visited[i] == -1)
                DFS(i, adjList, ret);
        }

        return ret;
    }

    private void DFS(
        int u,
        List<int>[] adjList,
        List<IList<int>> ret)
    {
        if (Visited[u] != -1)
            return;

        MinVisitedTime[u] = Visited[u] = time++;

        foreach (var v in adjList[u])
        {
            if (Visited[v] == -1)
            {
                Parent[v] = u;
                DFS(v, adjList, ret);

                // Update u minVisitedTime after calculating each v MinVisitedTime
                // V might has lower visited time by some other connections.
                MinVisitedTime[u] = Math.Min(MinVisitedTime[u], MinVisitedTime[v]);

                // If v's lowest visited time is greater than the visited time of U
                // It is a critical connection.
                if (MinVisitedTime[v] > Visited[u])
                    ret.Add(new List<int>() { u, v });
            }
            else
            {
                // Only care connections that we did not connect before.
                if (Parent[u] != v)
                    MinVisitedTime[u] = Math.Min(MinVisitedTime[u], Visited[v]);
            }
        }
    }

    private List<int>[] GetAdjList(
        int n,
        IList<IList<int>> con)
    {
        var ret = new List<int>[n];

        for (int i = 0; i < n; i++)
            ret[i] = new List<int>();

        foreach (var c in con)
        {
            int u = c[0];
            int v = c[1];

            ret[u].Add(v);
            ret[v].Add(u);
        }

        return ret;
    }

    private int[] GetNSizeArray(
        int n,
        int initialValue = 0)
    {
        var ret = new int[n];

        for (int i = 0; i < n; i++)
            ret[i] = initialValue;

        return ret;
    }
}