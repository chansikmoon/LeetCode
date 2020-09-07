public class Solution {
    public bool WordPattern(string pattern, string str) {
        string[] words = str.Split(' ');
        
        if (words.Length != pattern.Length)
            return false;
        
        Dictionary<char, string> map = new Dictionary<char, string>();
        
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