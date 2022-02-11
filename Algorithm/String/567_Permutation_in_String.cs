public class Solution {
    public bool CheckInclusion(string s1, string s2) {
        if (s1.Length > s2.Length)
            return false;
        
        var exp = new int[26];
        foreach (var c in s1)
            exp[c - 'a']++;
        
        var act = new int[26];
        
        for (int i = 0; i < s2.Length; i++)
        {
            act[s2[i] - 'a']++;
            
            if (s1.Length <= i)
                act[s2[i - s1.Length] - 'a']--;

            if (Equal(act, exp))
                return true;
        }
        
        return false;
    }
    
    private bool Equal(int[] act, int[] exp) {
        for (int i = 0; i < 26; i++)
        {
            if (act[i] != exp[i])
                return false;
        }
        
        return true;
    }
}