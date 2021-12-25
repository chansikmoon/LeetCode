public class Solution {
    public int Calculate(string s) {
        var numSt = new Stack<int>();
        int num = 0;
        char sign = '+';
        
        for (int i = 0; i < s.Length; i++)
        {
            if (char.IsDigit(s[i]))
            {
                num = num * 10 + (s[i] - '0');
            }
            
            if ((!char.IsWhiteSpace(s[i]) && !char.IsDigit(s[i])) || i == s.Length - 1)
            {
                
                if (sign == '+')
                    numSt.Push(num);
                else if (sign == '-')
                    numSt.Push(-num);
                else if (sign == '*')
                    numSt.Push(numSt.Pop() * num);
                else if (sign == '/')
                    numSt.Push(numSt.Pop() / num);
                
                num = 0;
                sign = s[i];
            }
        }
        
        return numSt.Sum();
    }
}