public class Solution {
    public IList<int> FindAnagrams(string s, string p) {
        var exp = new int[26];
        var act = new int[26];
        var ret = new List<int>();
        
        foreach (var c in p) {
            exp[c - 'a']++;
        }
        
        for (int r = 0; r < s.Length; r++) {
            int l = r - p.Length;
            
            if (l >= 0)
                act[s[l] - 'a']--;

            act[s[r] - 'a']++;
            
            if (IsTrue(act, exp))
                ret.Add(l + 1);
        }
        
        return ret;
    }
    
    private bool IsTrue(int[] a, int[] b) {
        for (int i = 0; i < 26; i++)
        {
            if (a[i] != b[i])
                return false;
        }
        
        return true;
    }
}