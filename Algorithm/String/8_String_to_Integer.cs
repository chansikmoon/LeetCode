public class Solution {
    public int MyAtoi(string s) {
        int sum = 0, sign = 1, i = 0;
        
        if (s.Length == 0)
            return sum;
        
        while (i < s.Length && s[i] == ' ')
            i++;
        
        if (i < s.Length && (s[i] == '+' || s[i] == '-'))
            sign = s[i++] == '+' ? 1 : -1;
        
        while (i < s.Length)
        {
            int digit = s[i] - '0';
            
            if (digit < 0 || digit > 9)
                break;
            
            if (Int32.MaxValue / 10 < sum || 
                Int32.MaxValue / 10 == sum && Int32.MaxValue % 10 < digit)
                    return sign == 1 ? Int32.MaxValue : Int32.MinValue;
                
            sum = sum * 10 + digit;
            i++;
        }
        
        return sum * sign;
    }
}