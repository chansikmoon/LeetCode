public class Solution {
    public IList<IList<string>> Partition(string s) {
        var ret = new List<IList<string>>();
        Backtracking(ret, new List<string>(), s, 0);
        return ret;
    }
    
    private void Backtracking(List<IList<string>> ret, List<string> list, string s, int index)
    {
        if (index >= s.Length)
        {
            ret.Add(new List<string>(list));
            return;
        }
        
        var sb = new StringBuilder();
        
        for (int i = index; i < s.Length; i++)
        {
            sb.Append(s[i]);
            
            var cand = sb.ToString();
            
            if (IsPalindrome(cand))
            {
                list.Add(cand);
                Backtracking(ret, list, s, i + 1);
                list.RemoveAt(list.Count - 1);
            }
        }
    }
    
    private bool IsPalindrome(string s)
    {
        int l = 0, r = s.Length - 1;
        
        while (l < r)
        {
            if (s[l++] != s[r--])
                return false;
        }
        
        return true;
    }
}