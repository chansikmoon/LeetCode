public class Solution {
    public bool IsBipartite(int[][] graph) {
        var colors = new int[graph.Length];
        
        for (int i = 0; i < graph.Length; i++)
        {
            if (colors[i] == 0 && !ValidColor(graph, colors, 1, i))
                return false;
        }
        
        return true;
    }
    
    private bool ValidColor(int[][] graph, int[] colors, int color, int node)
    {
        if (colors[node] != 0)
            return colors[node] == color;
        
        colors[node] = color;
        
        foreach (int next in graph[node])
        {
            if (!ValidColor(graph, colors, -color, next))
                return false;
        }
        
        return true;
    }
}