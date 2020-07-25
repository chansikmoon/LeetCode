public class Solution {
    public IList<IList<int>> AllPathsSourceTarget(int[][] graph) {
        List<List<int>> adjList = new List<List<int>>();
        
        foreach (int[] g in graph)
        {
            adjList.Add(new List<int>(g));
        }
        
        List<IList<int>> retval = new List<IList<int>>();
        
        // DFS(retval, adjList, new List<int>(){0}, 0);
        DFS2(graph, retval, new List<int>(), 0, graph.Length - 1);
        
        return retval;
    }
    
    private void DFS(List<IList<int>> retval, List<List<int>> adjList, List<int> path, int node)
    {
        if (adjList[node].Count == 0)
        {
            retval.Add(new List<int>(path));
        }
        
        foreach (int nextNode in adjList[node])
        {
            path.Add(nextNode);
            DFS(retval, adjList, path, nextNode);
            path.Remove(nextNode);
        }
    }
    
    private void DFS2(int[][] graph, List<IList<int>> retval, List<int> path, int source, int destination)
    {
        if (source == destination)
            retval.Add(path);
        
        path.Add(source);
        
        foreach (int nextNode in graph[source])
        {
            DFS2(graph, retval, new List<int>(path), nextNode, destination);
        }
    }
}