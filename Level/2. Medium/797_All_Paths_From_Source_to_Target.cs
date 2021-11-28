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

public class Solution2 {
    private int _dest { get; set; }
    private IList<IList<int>> ret { get; set; }
    public IList<IList<int>> AllPathsSourceTarget(int[][] graph) {
        _dest = graph.Length - 1;
        ret = new List<IList<int>>();
        DFS(graph, new List<int>(), 0);
        return ret;
    }
    
    private void DFS(int[][] graph, List<int> list, int curr)
    {
        if (curr == _dest)
        {
            var toAdd = new List<int>(list);
            toAdd.Add(curr);
            ret.Add(toAdd);
            return;
        }
        
        list.Add(curr);
        
        foreach (int next in graph[curr])
        {
            DFS(graph, list, next);
        }
        
        list.RemoveAt(list.Count - 1);
    }
}