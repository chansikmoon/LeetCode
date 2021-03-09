public class Solution {
    public int RemovePalindromeSub(string s) {
        char[] charArray = s.ToCharArray();
        Array.Reverse( charArray );
        string reversedString = new string( charArray );
        
        return s.Length == 0 ? 0 : s.Equals(reversedString) ? 1 : 2;
    }
}