public class Solution {
    public int MinFlips(string s) {
        int n = s.Length;
        s += s;
        
        var s1 = new char[s.Length];
        var s2 = new char[s.Length];
        
        for (int i = 0; i < s.Length; i++)
        {
            s1[i] = i % 2 == 0 ? '0' : '1';
            s2[i] = i % 2 == 0 ? '1' : '0';
        }
        
        int ret1 = 0, ret2 = 0, ret = Int32.MaxValue;
        
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] != s1[i]) ret1++;
            if (s[i] != s2[i]) ret2++;
            
            if (i >= n)
            {
                if (s[i - n] != s1[i - n]) ret1--;
                if (s[i - n] != s2[i - n]) ret2--;
            }
            
            if (i >= n - 1)
                ret = Math.Min(ret, Math.Min(ret1, ret2));
        }
        
        return ret;
    }
}