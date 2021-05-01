public class Solution {
    public string ModifyString(string s) {
        var charArr = s.ToCharArray();
        
        for (int i = 0; i < charArr.Length; i++)
        {
            if (charArr[i] == '?')
            {
                for (char c = 'a'; c <= 'z'; c++)
                {
                    if (i > 0 && charArr[i-1] == c)
                        continue;
                    if (i + 1 < s.Length && charArr[i+1] == c)
                        continue;
                    
                    charArr[i] = c;
                }
            }
        }
        
        return new string(charArr);
    }
}