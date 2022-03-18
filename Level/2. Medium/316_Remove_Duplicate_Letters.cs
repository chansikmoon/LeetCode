public class Solution {
    // O(n)
    // O(1)
    // Revisited on 03/18/2022
    public string RemoveDuplicateLetters(string s) {
        int[] lastAppear = new int[26];
        bool[] seen = new bool[26];
        
        // O(n)
        for (int i = 0; i < s.Length; i++)
            lastAppear[s[i] - 'a'] = i;
        
        StringBuilder sb = new StringBuilder();
        
         // O(n)
        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            
            if (seen[c - 'a'])
                continue;
            
            // sb.Length > 0 && sb[sb.Length - 1] > c : Compare the current letter with the last letter in sb.
            // lastAppear[sb[sb.Length - 1] - 'a'] > i : If the last appeared index of the last letter in sb is greater than the current index, 
            //                                           then it means there is at least one more same character later. Thus, it can be removed for now.
            while (sb.Length > 0 && sb[sb.Length - 1] > c && lastAppear[sb[sb.Length - 1] - 'a'] > i)
            {
                char removeChar = sb[sb.Length - 1];
                seen[removeChar - 'a'] = false;
                sb.Remove(sb.Length - 1, 1);
            }
            
            sb.Append(c);
            seen[c - 'a'] = true;
        }
        
        return sb.ToString();
    }
}
                 