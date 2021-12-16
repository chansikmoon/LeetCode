public class Solution {
    public IList<int> FindMinHeightTrees(int n, int[][] edges) {
        var leaves = new List<int>();
        
        if (n <= 2)
        {
            for (int i = 0; i < n; i++)
                leaves.Add(i);
            return leaves;
        }
        
        var adjList = new List<int>[n];
        
        for (int i = 0; i < n; i++)
            adjList[i] = new List<int>();
        
        foreach (var e in edges)
        {
            adjList[e[0]].Add(e[1]);
            adjList[e[1]].Add(e[0]);
        }
        
        for (int i = 0; i < n; i++)
        {
            if (adjList[i].Count == 1)
                leaves.Add(i);
        }
        
        
        int remainingLeaves = n;
        
        // If there is only one node left, then that is it.
        // If there are two nodes left, then either of them could be a possible root.

        // Time: O(|v|), we simply repeat the loop until you have no more and you process each node once.
        while (remainingLeaves > 2)
        {
            remainingLeaves -= leaves.Count;
            var newLeaves = new List<int>();
            
            foreach (int leaf in leaves)
            {
                foreach (int val in adjList[leaf])
                {
                    adjList[val].Remove(leaf);
                    if (adjList[val].Count == 1)
                        newLeaves.Add(val);
                }
            }
            
            leaves = newLeaves;
        }
        
        return leaves;
    }
}