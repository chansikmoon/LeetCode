public class Solution {
    Dictionary<int, List<int>> adjList;
    int[] ans;
    int[] c = new int[26];
    string l;
    public int[] CountSubTrees(int n, int[][] edges, string labels) {
        adjList = new Dictionary<int, List<int>>();
        ans = new int[n];
        l = labels;
        
        foreach (int[] edge in edges)
        {
            if (!adjList.ContainsKey(edge[0]))
                adjList.Add(edge[0], new List<int>());
            
            if (!adjList.ContainsKey(edge[1]))
                adjList.Add(edge[1], new List<int>());
            
            adjList[edge[0]].Add(edge[1]);
            adjList[edge[1]].Add(edge[0]);
        }
        
        DFS(0, -1);
        
        return ans;
    }
    
    // Idea from WilliamLin
    private void DFS(int u, int p)
    {
        int prev = c[l[u] - 'a']++;
        foreach (int v in adjList[u])   
        {
            if (v != p)
                DFS(v, u);
        }
        ans[u] = c[l[u] - 'a'] - prev;
    }
}