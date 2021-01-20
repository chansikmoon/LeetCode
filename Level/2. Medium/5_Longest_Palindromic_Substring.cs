public class Solution {
    // TC: O(n^2)
    // SC: O(1)
    public string LongestPalindrome(string s) {
        int left = 0, length = 0, maxLength = 0;
        
        for (int i = 0; i < s.Length; i++)
        {
            int odd = ExpandFromCenter(s, i, i);
            int even = ExpandFromCenter(s, i-1, i);
            int len = Math.Max(odd, even);
            
            if (len > length)
            {
                length = len;
                left = i - len/2;
            }
        }
        
        return s.Substring(left, length);
    }
    
    private int ExpandFromCenter(string s, int l, int r)
    {
        while (l >= 0 && r < s.Length && s[l] == s[r])
        {
            l--;
            r++;
        }
        
        return r-l-1;
    }
    
    // TLE
    public string BruteForce(string s)
    {
        int n = s.Length;
        
        string ret = "";
        
        for (int len = 1; len <= n; len++)
        {
            for (int i = 0; i <= n-len; i++)
            {
                string tmp = s.Substring(i, len);
                if (IsPalindrome(tmp))
                    ret = tmp;
            }
        }
        
        return ret;
    }
    
    public bool IsPalindrome(string s)
    {
        for (int i = 0, j = s.Length - 1; i <= j; i++, j--)
        {
            if (s[i] != s[j])
                return false;
        }
        
        return true;
    }
}