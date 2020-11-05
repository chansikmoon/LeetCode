public class Solution {
    public IList<int> FindMinHeightTrees(int n, int[][] edges) {
        Dictionary<int, HashSet<int>> neighbors = new Dictionary<int, HashSet<int>>();
        List<int> leaves = new List<int>();
        
        if (n <= 2)
        {
            for (int i = 0; i < n; i++)
                leaves.Add(i);
            return leaves;
        }
        
        for (int i = 0; i < n; i++)
        {
            neighbors.Add(i, new HashSet<int>());
        }
        
        foreach (int[] edge in edges)
        {
            neighbors[edge[0]].Add(edge[1]);
            neighbors[edge[1]].Add(edge[0]);
        }
        
        foreach (var kvp in neighbors)
        {
            if (kvp.Value.Count == 1)
                leaves.Add(kvp.Key);
        }
        
        int remainingLeaves = n;
        
        // If there is only one node left, then that is it.
        // If there are two nodes left, then either of them could be a possible root.

        // Time: O(|v|), we simply repeat the loop until you have no more and you process each node once.
        while (remainingLeaves > 2)
        {
            remainingLeaves -= leaves.Count;
            List<int> newLeaves = new List<int>();
            
            foreach (int leaf in leaves)
            {
                foreach (int neighbor in neighbors[leaf])
                {
                    neighbors[neighbor].Remove(leaf);
                    if (neighbors[neighbor].Count == 1)
                        newLeaves.Add(neighbor);
                }
            }
            
            leaves = newLeaves;
        }
        
        return leaves;
    }
}