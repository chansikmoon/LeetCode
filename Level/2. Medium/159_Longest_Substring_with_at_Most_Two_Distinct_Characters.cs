public class Solution {
    public int LengthOfLongestSubstringTwoDistinct(string s) {
        int ret = 0;
        Dictionary<char, int> map = new Dictionary<char, int>();
        
        for (int l = 0, r = 0; r < s.Length; r++)
        {
            if (!map.ContainsKey(s[r]))
                map.Add(s[r], 0);
            
            map[s[r]]++;
            
            while (map.Count > 2)
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