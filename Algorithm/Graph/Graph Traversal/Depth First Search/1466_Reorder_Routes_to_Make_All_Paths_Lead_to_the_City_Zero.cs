public class Solution {
    public int MinReorder(int n, int[][] connections) {
        var fromTo = new HashSet<int>[n];
        var toFrom = new HashSet<int>[n];
        
        for (int i = 0; i < n; i++)
        {
            fromTo[i] = new HashSet<int>();
            toFrom[i] = new HashSet<int>();
        }
        
        foreach (var c in connections)
        {
            fromTo[c[0]].Add(c[1]);
            toFrom[c[1]].Add(c[0]);
        }
        
        return DFS(fromTo, toFrom, 0);
    }
    
    private int DFS(HashSet<int>[] fromTo, HashSet<int>[] toFrom, int curr)
    {
        int ret = 0;
        
        foreach (int n in fromTo[curr])
        {
            ret++;
            toFrom[n].Remove(curr);
            ret += DFS(fromTo, toFrom, n);
        }
        
        foreach (int n in toFrom[curr])
        {
            fromTo[n].Remove(curr);
            ret += DFS(fromTo, toFrom, n);
        }
        
        return ret;
    }
    
    public int BruteForce(int n, int[][] connections)
    {
        var adjList = new List<int>[n];
        var dirList = new HashSet<int>[n];
        
        for (int i = 0; i < n; i++)
        {
            adjList[i] = new List<int>();
            dirList[i] = new HashSet<int>();
        }
        
        foreach (var con in connections)
        {
            adjList[con[0]].Add(con[1]);
            adjList[con[1]].Add(con[0]);
            
            dirList[con[0]].Add(con[1]);
        }
        
        var visited = new bool[n];
        visited[0] = true;
        
        return BruteForceDFS(adjList, dirList, visited, 0, -1) - 1;
    }
    
    private int BruteForceDFS(List<int>[] adjList, HashSet<int>[] dirList, bool[] visited, int curr, int prev)
    {
        var next = new List<int>();
        
        foreach (int n in adjList[curr])
        {
            if (!visited[n])
                next.Add(n);
        }
        
        int ret = 0;
        
        foreach (int n in next)
        {
            visited[n] = true;
            ret += BruteForceDFS(adjList, dirList, visited, n, curr);
            visited[n] = false;
        }
        
        return ret + (dirList[curr].Contains(prev) ? 0 : 1);
    }
}