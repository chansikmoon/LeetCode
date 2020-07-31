public class Solution {
    private Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();
    
    public IList<string> WordBreak(string s, IList<string> wordDict) {
        List<string> retval = new List<string>();
        
        if (string.IsNullOrWhiteSpace(s) || s.Length == 0)
            return retval;
        
        if (map.ContainsKey(s))
            return map[s];
        
        if (wordDict.Contains(s))
            retval.Add(s);
        
        for (int i = 1; i < s.Length; i++)
        {
            string temp = s.Substring(i);
            if (wordDict.Contains(temp))
            {
                IList<string> list = WordBreak(s.Substring(0, i), wordDict);
                foreach (string l in list)
                    retval.Add(l + " " + temp);
            }
        }
        
        map.Add(s, retval);
        return retval;
    }
}