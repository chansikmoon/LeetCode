public class Solution {
    public string ToGoatLatin(string S) {
        HashSet<char> vowels = new HashSet<char>(){'a', 'e', 'i', 'u', 'o', 'A', 'E', 'I', 'U', 'O'};
        string[] words = S.Split(' ');
        StringBuilder ret = new StringBuilder();
        int i = 1;
        
        foreach (string w in words)
        {
            if (!vowels.Contains(w[0]))
            {
                ret.Append(w.Substring(1));
                ret.Append(w[0]);
            }
            else
                ret.Append(w);
            
            ret.Append("ma");
            ret.Append('a', i++);
            ret.Append(" ");
        }
        
        return ret.ToString().Trim();
    }
}