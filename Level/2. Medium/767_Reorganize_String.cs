public class Solution {
    public string ReorganizeString(string S) {
        int[] ch = new int[26];
        int maximum = 0, maximumLetter = 0;
        
        for (int i = 0; i < S.Length; i++)
            ch[S[i] - 'a']++;
        
        for (int i = 0; i < ch.Length; i++)
        {
            if (ch[i] > maximum)
            {
                maximum = ch[i];
                maximumLetter = i;
            }
        }
        
        // a b a b a b a => a: 4, b: 3
        // 4 > (7 + 1) / 2 vs 4 > 7 / 2
        if (maximum > (S.Length + 1) / 2)
            return "";
        
        char[] ret = new char[S.Length];
        int index = 0;
        while (ch[maximumLetter]-- > 0)
        {
            ret[index] = (char) (maximumLetter + 'a');
            index += 2;
        }
        
        for (int i = 0; i < 26; i++)
        {
            while (ch[i]-- > 0)
            {
                if (index >= ret.Length) 
                    index = 1;
                
                ret[index] = (char) (i + 'a');
                index += 2;
            }
        }
            
        return new string(ret);
    }
}