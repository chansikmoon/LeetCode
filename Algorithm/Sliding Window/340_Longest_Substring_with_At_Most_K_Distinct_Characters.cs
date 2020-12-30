public class Solution {
    public int LengthOfLongestSubstringKDistinct(string s, int k) {
        var map = new Dictionary<char, int>();
        int ret = 0;
        for (int l = 0, r = 0; r < s.Length; r++)
        {
            if (!map.ContainsKey(s[r]))
                map.Add(s[r], 0);
            map[s[r]]++;
            
            while (map.Count > k)
            {
                map[s[l]]--;
                
                if (map[s[l]] == 0)
                    map.Remove(s[l]);
                
                l++;
            }
            
            ret = Math.Max(ret, r - l + 1);
        }
        
        return ret;
    }
}