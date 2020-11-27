public class Solution {
    public int LongestSubstring(string s, int k) {
        int n = s.Length;
        if (n == 0 || k > n)
            return 0;
        if (k == 0)
            return n;
        
        Dictionary<char, int> map = new Dictionary<char, int>();
        foreach (char c in s)
        {
            if (!map.ContainsKey(c))
                map.Add(c, 0);
            map[c]++;
        }
        
        int index = 0;
        while (index < n && map[s[index]] >= k)
            index++;
        
        if (index == n)
            return n;
        
        int left = LongestSubstring(s.Substring(0, index), k);
        int right = LongestSubstring(s.Substring(index+1), k);
        
        return Math.Max(left, right);
    }
}