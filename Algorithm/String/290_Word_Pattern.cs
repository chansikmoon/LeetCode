public class Solution {
    public bool WordPattern(string pattern, string s) {
        var words = s.Split(" ");
        var map = new Dictionary<char, string>();
        
        if (words.Length != pattern.Length)
            return false;
        
        for (int i = 0; i < words.Length; i++)
        {    
            if (!map.ContainsKey(pattern[i]) && !map.Any(x => x.Value == words[i]))
                map[pattern[i]] = words[i];
            
            if (!map.ContainsKey(pattern[i]) || map[pattern[i]] != words[i])
                return false;
        }
        
        return true;
    }
}