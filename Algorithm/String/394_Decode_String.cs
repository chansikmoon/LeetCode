public class Solution {
    public string DecodeString(string s) {
        var strStack = new Stack<StringBuilder>();
        var freqStack = new Stack<int>();
        
        var sb = new StringBuilder();
        int num = 0;
        
        for (int i = 0; i < s.Length; i++)
        {
            if (char.IsDigit(s[i]))
            {
                num = num * 10 + s[i] - '0';
            }
            else if (s[i] == '[')
            {
                freqStack.Push(num);
                strStack.Push(sb);
                
                num = 0;
                sb = new StringBuilder();
            }
            else if (s[i] == ']')
            {
                int freq = freqStack.Pop();
                StringBuilder repeatStr = sb;
                sb = strStack.Pop();
                
                while (freq-- > 0)
                    sb.Append(repeatStr);
            }
            else
            {
                sb.Append(s[i]);
            }
        }
        
        return sb.ToString();
    }
}