public class Solution {
    public int LengthOfLongestSubstring(string s) {
        var _set = new HashSet<char>();
        
        int ret = 0;
        
        for (int l = 0, r = 0; r < s.Length; r++)
        {
            while (_set.Contains(s[r]))
                _set.Remove(s[l++]);
            
            _set.Add(s[r]);
            ret = Math.Max(ret, r - l + 1);
        }
        
        return ret;
    }
}