public class Solution {
    public string DecodeString(string s) {
        Stack<int> numSt = new Stack<int>();
        Stack<StringBuilder> sbSt = new Stack<StringBuilder>();
        
        int i = 0, num = 0;
        StringBuilder sb = new StringBuilder();
        
        while (i < s.Length)
        {
            if (Char.IsDigit(s[i]))
            {
                num = num * 10 + s[i] - '0';
            }
            else if (s[i] == '[')
            {
                numSt.Push(num);
                sbSt.Push(sb);
                
                num = 0;
                sb = new StringBuilder();
            }
            else if (s[i] == ']')
            {
                int freq = numSt.Pop();
                StringBuilder repeatStr = sb;
                sb = sbSt.Pop();
                
                while (freq-- > 0)
                    sb.Append(repeatStr);
            }
            else
            {
                sb.Append(s[i]);
            }
            
            i++;
        }
        
        return sb.ToString();
    }
}