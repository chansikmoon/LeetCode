public class Solution {
    public bool IsAnagram(string s, string t) {
        var arr = new int[26];
        
        for (int i = 0; i < s.Length; i++)
            arr[s[i] - 'a']++;
        
        for (int i = 0; i < t.Length; i++)
            arr[t[i] - 'a']--;
        
        return !arr.Any(x => x != 0);
    }
}