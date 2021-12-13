public class Solution {
    public int MaxPower(string s) {
        int max = 1;
        
        for (int i = 1, count = 1; i < s.Length; i++)
        {
            if (s[i-1] != s[i])
                count = 0;
            max = Math.Max(max, ++count);
        }
        
        return max;
    }
}