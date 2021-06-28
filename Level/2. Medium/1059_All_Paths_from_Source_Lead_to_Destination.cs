public class Solution {
    public bool LeadsToDestination(int n, int[][] edges, int source, int destination) {
        var adjList = new List<int>[n];
        
        for (int i = 0; i < n; i++)
            adjList[i] = new List<int>();
        
        foreach (var edge in edges)
            adjList[edge[0]].Add(edge[1]);
        
        return DFS(adjList, new bool[n], source, destination);
    }
    
    private bool DFS(List<int>[] adjList, bool[] visited, int u, int dest)
    {
        if (adjList[u].Count == 0)
            return u == dest;
        
        if (visited[u])
            return false;
        
        visited[u] = true;
        
        foreach (var v in adjList[u])
        {
            if (!DFS(adjList, visited, v, dest))
                return false;
        }
        
        visited[u] = false;
        
        return true;
    }
}