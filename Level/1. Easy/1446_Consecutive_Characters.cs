public class Solution {
    public int MaxPower(string s) {
        int ret = 0;
        
        for (int l = 0, r = 0; r < s.Length; r++)
        {
            if (s[l] != s[r])
                l = r;
            
            ret = Math.Max(ret, r - l + 1);
        }
        
        return ret;
    }
}