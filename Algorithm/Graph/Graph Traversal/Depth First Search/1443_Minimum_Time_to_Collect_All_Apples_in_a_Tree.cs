public class Solution {
    public int MinTime(int n, int[][] edges, IList<bool> hasApple) {
        var adjList = new List<int>[n];
        var visited = new HashSet<int>();
        
        for (int i = 0; i < n; i++)
            adjList[i] = new List<int>();
        
        foreach (var edge in edges)
        {
            adjList[edge[0]].Add(edge[1]);
            adjList[edge[1]].Add(edge[0]);
        }
        
        return DFS(adjList, visited, hasApple, 0);
    }
    
    private int DFS(
        List<int>[] adjList, 
        HashSet<int> visited, 
        IList<bool> apple, 
        int root)
    {
        if (visited.Contains(root) || adjList[root].Count == 0)
            return 0;
        
        visited.Add(root);
        
        int ret = 0;
        
        foreach (var child in adjList[root])
        {
            if (visited.Contains(child))
                continue;
            
            if (apple[child])
                ret += 2;
            
            ret += DFS(adjList, visited, apple, child);
        }
        
        if (root != 0 && ret > 0 && !apple[root])
            ret += 2;
        
        visited.Remove(root);
        
        return ret;
    }
}