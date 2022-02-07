public class Solution {
    public char FindTheDifference(string s, string t) {
        var arr = new int[26];
        
        for (int i = 0; i < s.Length; i++)
        {
            arr[s[i] - 'a']++;
        }
        
        for (int i = 0; i < t.Length; i++)
        {
            if (arr[t[i] - 'a']-- == 0)
                return t[i];
        }
        
        return 'a';
    }
}