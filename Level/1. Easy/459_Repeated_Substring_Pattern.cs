public class Solution {
    public bool RepeatedSubstringPattern(string s) {
        int length = s.Length;
        
        for (int i = 1; i <= length / 2; i++)
        {
            if (length % i == 0 && s.Substring(0, length - i) == s.Substring(i))
                return true;
        }
        
        return false;
    }
}