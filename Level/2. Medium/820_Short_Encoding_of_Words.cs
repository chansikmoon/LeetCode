public class Solution {
    public int MinimumLengthEncoding(string[] words) {
        var _set = new HashSet<string>();
        
        foreach (var w in words)
            _set.Add(w);
        
        foreach (var w in words)
        {
            for (int i = 1; i < w.Length; i++)
                _set.Remove(w.Substring(i));
        }
        
        int ret = 0;
        
        foreach (var w in _set)
            ret += w.Length + 1;
        
        return ret;
    }
}