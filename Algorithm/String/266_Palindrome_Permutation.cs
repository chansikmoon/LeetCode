public class Solution {
    public bool CanPermutePalindrome(string s) {
        HashSet<char> charSet = new HashSet<char>();
        
        for (int i = 0; i < s.Length; i++)
        {
            if (!charSet.Add(s[i]))
                charSet.Remove(s[i]);
        }
        
        return charSet.Count <= 1;
    }
}