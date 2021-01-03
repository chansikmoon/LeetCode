public class Solution {
    public int CountPairs(int[] deliciousness) {
        var map = new Dictionary<int, int>();
        int MOD = 1000000007; 
        
        for (int i = 0; i < deliciousness.Length; i++)
        {
            if (!map.ContainsKey(deliciousness[i]))
                map.Add(deliciousness[i], 0);
            
            map[deliciousness[i]]++;
        }
        
        int ret = 0;
        
        foreach (var kvp in map)
        {
            for (int x = 1; x <= (1 << 21); x *= 2)
            {
                int targetKey = x - kvp.Key;
                // it is like i <= j
                // if j is less than i, then continue;
                if (targetKey < kvp.Key)
                    continue;
                if (map.ContainsKey(targetKey))
                {
                    if (targetKey == kvp.Key)
                        ret += (int) ((long)kvp.Value * (kvp.Value - 1) / 2 % MOD);
                    else
                        ret += (int) ((long)map[targetKey] * kvp.Value % MOD);
                    
                    if (ret >= MOD)
                        ret -= MOD;
                }
            }
        }
        
        return ret;
    }
}