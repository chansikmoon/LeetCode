public class Solution {
    public int LongestPalindrome(string s) {
        int[] chars = new int[128];
        int retval = 0;
        
        foreach (char c in s)
        {
            if (++chars[(int)c] == 2)
            {
                retval += 2;
                chars[(int)c] = 0;
            }
        }
        
        return retval == s.Length ? retval : retval + 1;
    }
}