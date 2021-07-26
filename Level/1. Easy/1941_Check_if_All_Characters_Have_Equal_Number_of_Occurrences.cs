public class Solution {
    public bool AreOccurrencesEqual(string s) {
        var map = new Dictionary<int, int>();
        
        for (int i = 0; i < s.Length; i++)
        {
            int idx = s[i] - 'a';
            
            if (!map.ContainsKey(idx))
                map.Add(idx, 0);
            map[idx]++;
        }
        
        int freq = map.First().Value;
        
        return map.All(x => x.Value == freq);
    }
}