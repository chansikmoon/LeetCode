public class Solution {
    public IList<string> LetterCasePermutation(string S) {
        var list = new List<StringBuilder>();
        list.Add(new StringBuilder());
        
        foreach (char c in S)
        {
            int n = list.Count;
            if (Char.IsLetter(c))
            {
                for (int i = 0; i < n; i++)
                {
                    list.Add(new StringBuilder(list[i].ToString()));
                    list[i].Append(Char.ToLower(c));
                    list[n+i].Append(Char.ToUpper(c));
                }
            }
            else
            {
                for (int i = 0; i < n; i++)
                    list[i].Append(c);
            }
        }
        
        var ret = new List<string>();
        foreach (var sb in list)
            ret.Add(sb.ToString());
        
        return ret;
    }
}