public class Solution {
    public IList<int> FindNumOfValidWords(string[] words, string[] puzzles) {
        var map = new Dictionary<int, int>();
        
        foreach (var word in words)
        {
            int mask = MaskWord(word);
            
            if (!map.ContainsKey(mask))
                map.Add(mask, 0);
            
            map[mask]++;
        }
        
        var ret = new List<int>();
        
        foreach (var p in puzzles)
        {
            int mask = MaskWord(p);
            int sub = mask, first = (1 << (p[0] - 'a')), count = 0;
            
            while (sub > 0)
            {
                if ((sub & first) > 0 && map.ContainsKey(sub))
                    count += map[sub];
                    
                sub = mask & (sub - 1);
            }
            
            ret.Add(count);
        }
        
        return ret;
    }
    
    private int MaskWord(string str)
    {
        int ret = 0;
        
        foreach (char c in str)
            ret |= (1 << (c - 'a'));
        
        return ret;
    }
}
