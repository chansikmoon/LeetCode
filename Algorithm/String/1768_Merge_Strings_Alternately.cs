public class Solution {
    public string MergeAlternately(string word1, string word2) {
        var sb = new StringBuilder();
        int i = 0, j = 0;
        
        while (i < word1.Length || j < word2.Length)
        {
            if (i < word1.Length)
                sb.Append(word1[i++]);
            
            if (j < word2.Length)
                sb.Append(word2[j++]);
        }
        
        return sb.ToString();
    }
}