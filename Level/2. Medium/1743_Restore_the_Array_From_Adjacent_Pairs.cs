public class Solution {
    public int[] RestoreArray(int[][] adjacentPairs) {
        var map = new Dictionary<int, List<int>>();
        
        foreach (var ap in adjacentPairs)
        {
            if (!map.ContainsKey(ap[0]))
                map.Add(ap[0], new List<int>());
            
            if (!map.ContainsKey(ap[1]))
                map.Add(ap[1], new List<int>());
            
            map[ap[0]].Add(ap[1]);
            map[ap[1]].Add(ap[0]);
        }
        
        var q = new Queue<int>();
        var visited = new HashSet<int>();
        foreach (var kvp in map)
        {
            if (kvp.Value.Count == 1)
            {
                q.Enqueue(kvp.Key);
                break;
            }
        }
        
        var ret = new List<int>();
        while (q.Count > 0)
        {
            var curr = q.Dequeue();
            
            if (visited.Add(curr))
            {
                ret.Add(curr);
                
                foreach (int neighbor in map[curr])
                {
                    if (!visited.Contains(neighbor))
                        q.Enqueue(neighbor);
                }
            }
        }
        
        return ret.ToArray();
    }
}