public class Solution {
    public int[] FindOrder(int n, int[][] prs) {
        List<int>[] graph = new List<int>[n];
        List<int> retval = new List<int>();
        int[] visited = new int[n];
        
        for (int i = 0; i < n; i++)
            graph[i] = new List<int>();
        
        foreach (var pr in prs)
            graph[pr[1]].Add(pr[0]);
        
        for (int i = 0; i < n; i++)
            if (!Topo(graph, visited, retval, i))
                return new int[n];
        
        retval.Reverse();
        
        return retval.ToArray();
    }
    
    private bool Topo(List<int>[] graph, int[] visited, List<int> retval, int pre)
    {
        if (visited[pre] != 0)
            return visited[pre] == 2;
        
        visited[pre] = 1;
        
        foreach (int next in graph[pre])
        {
            if (!Topo(graph, visited, retval, next))
                return false;
        }
        
        visited[pre] = 2;
        retval.Add(pre);
        return true;
    }
}