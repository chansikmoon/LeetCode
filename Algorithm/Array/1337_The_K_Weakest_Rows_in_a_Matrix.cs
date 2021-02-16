public class Solution {
    public int[] KWeakestRows(int[][] mat, int k) {
        var map = new Dictionary<int, List<int>>();
        
        for (int i = 0; i < mat.Length; i++)
        {
            int numOfSol = 0;
            for (int j = 0; j < mat[i].Length; j++)
            {
                if (mat[i][j] == 1)
                    numOfSol++;
            }
            
            if (!map.ContainsKey(numOfSol))
                map.Add(numOfSol, new List<int>());
            
            map[numOfSol].Add(i);
        }
        
        int minSol = Int32.MaxValue, maxSol = Int32.MinValue;
        
        foreach (var kvp in map)
        {
            minSol = Math.Min(minSol, kvp.Key);
            maxSol = Math.Max(maxSol, kvp.Key);
        }
        
        var ret = new List<int>();
        
        for (int i = minSol; i <= maxSol; i++)
        {
            if (!map.ContainsKey(i))
                continue;
                
            var sorted = map[i].OrderBy(x => x).ToList();
            
            for (int j = 0; j < sorted.Count && k > 0; j++)
            {
                ret.Add(sorted[j]);
                k--;
            }
        }
        
        return ret.ToArray();
    }
}