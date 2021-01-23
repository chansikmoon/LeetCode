public class Solution {
    public bool IsOneEditDistance(string s, string t) {
        int n1 = s.Length, n2 = t.Length;
        
        if (n1 > n2)
            return IsOneEditDistance(t, s);
        
        bool isSameLength = n1 == n2;
        
        for (int i = 0; i < n1; i++)
        {
            if (s[i] != t[i])
            {
                if (isSameLength)
                    return s.Substring(i+1) == t.Substring(i+1);
                else
                    return s.Substring(i) == t.Substring(i+1);
            }
        }
        
        return Math.Abs(n2 - n1) == 1;
    }
}