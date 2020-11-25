public class Solution {
    public int Calculate(string s) {
        Stack<int> nums = new Stack<int>();
        int num = 0;
        char sign = '+';
        
        for (int i = 0; i < s.Length; i++)
        {
            if (char.IsDigit(s[i]))
                num = num * 10 + (s[i] - '0');
            
            if ((!char.IsWhiteSpace(s[i]) && !char.IsDigit(s[i])) || i == s.Length - 1)
            {
                if (sign == '+')
                    nums.Push(num);
                else if (sign == '-')
                    nums.Push(-num);
                else if (sign == '*')
                    nums.Push(nums.Pop() * num);
                else if (sign == '/')
                    nums.Push(nums.Pop() / num);
                
                sign = s[i];
                num = 0;
            }
        }
        
        int ret = 0;
        foreach (int n in nums)
        {
            ret += n;
        }
        
        return ret;
    }
}