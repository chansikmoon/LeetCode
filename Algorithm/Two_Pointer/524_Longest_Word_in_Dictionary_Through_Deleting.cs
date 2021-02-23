public class Solution {
    public string FindLongestWord(string s, IList<string> d) {
        string ret = "";
        foreach (string w in d)
        {
            if (IsInWord(w, s))
            {
                if (w.Length > ret.Length)
                    ret = w;
                if (w.Length == ret.Length && w.CompareTo(ret) < 0)
                    ret = w;
            }
        }
        
        return ret;
    }
    
    public bool IsInWord(string w, string s)
    {
        int i = 0, j = 0;
        
        while (i < w.Length && j < s.Length)
        {
            if (w[i] == s[j])
                i++;
            j++;
        }
        
        return i == w.Length;
    }
}