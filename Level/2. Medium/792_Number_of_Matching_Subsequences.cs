public class Solution {
    public int NumMatchingSubseq(string s, string[] words) {
        var map = new List<StringBuilder>[26];
        
        for (int i = 0; i < 26; i++)
            map[i] = new List<StringBuilder>();
        
        foreach (var word in words)
        {
            int idx = word[0] - 'a';
            map[idx].Add(new StringBuilder(word));
        }
        
        int ret = 0;
        
        // n
        foreach (var c in s)
        {
            int idx = c - 'a';
            
            var next = new List<StringBuilder>();
            
            // m
            foreach (var sb in map[idx])
            {
                sb.Remove(0, 1);
                if (sb.Length == 0)
                    ret++;
                else
                    next.Add(sb);
            }
            
            map[idx] = new List<StringBuilder>();
            
            foreach (var sb in next)
                map[sb[0] - 'a'].Add(sb);
        }
        
        return ret;
    }
}
