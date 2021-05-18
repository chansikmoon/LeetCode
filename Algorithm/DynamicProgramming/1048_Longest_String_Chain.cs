public class Solution {
    public int LongestStrChain(string[] words) {
        // O(n log(n))
        Array.Sort(words, (a,b) => a.Length - b.Length);
        
        var map = new Dictionary<string, int>();
        int ret = 0;
        
        // O(n* k^2)
        foreach (var w in words)
        {
            if (!map.ContainsKey(w))
                map.Add(w, 1);
           
            // O(k)
            for (int i = 0; i < w.Length; i++)
            {
                // O(k)
                var sb = new StringBuilder(w);
                var prev = sb.Remove(i, 1).ToString();
                
                if (map.ContainsKey(prev) && map[prev] + 1 > map[w])
                    map[w] = map[prev] + 1;
            }
            
            ret = Math.Max(ret, map[w]);
        }
        
        return ret;
    }
}