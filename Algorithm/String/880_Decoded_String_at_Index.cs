public class Solution {
    public string DecodeAtIndex(string s, int k) {
        long n = 0;
        int i = 0;
        for (; n < k; i++)
            n = Char.IsDigit(s[i]) ? n * (s[i] - '0') : n + 1;
            
        while (i-- > 0)
        {
            if (Char.IsDigit(s[i]))
            {
                n /= (s[i] - '0');
                k %= (int) n;
            }
            else if (k % n-- == 0)
                return s[i].ToString();
        }
        
        return string.Empty;
    }
}