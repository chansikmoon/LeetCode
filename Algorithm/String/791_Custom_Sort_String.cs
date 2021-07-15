public class Solution {
    public string CustomSortString(string order, string str) {
        var counts = new int[26];
        int n = str.Length;
        
        for (int i = 0; i < n; i++)
            counts[str[i] - 'a']++;
        
        var sb = new StringBuilder(n);
        
        for (int i = 0; i < order.Length; i++)
        {
            int idx = order[i] - 'a';
            sb.Append(order[i], counts[idx]);
            counts[idx] = 0;
        }
        
        for (int i = 0; i < 26; i++)
        {
            if (counts[i] > 0)
                sb.Append((char)(i + 'a'), counts[i]);
        }
        
        return sb.ToString();
    }
}