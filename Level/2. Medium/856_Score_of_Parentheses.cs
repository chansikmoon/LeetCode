public class Solution {
    public int ScoreOfParentheses(string s) {
        int ret = 0, shift = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '(')
                shift++;
            else
                shift--;
            
            if (s[i] == ')' && s[i-1] == '(')
                ret += 1 << shift;
        }
        
        return ret;
    }
    
    private int Solution1(string s)
    {
        var st = new Stack<int>();
        int sum = 0;
        foreach (char c in s)
        {
            if (c == '(')
            {
                st.Push(sum);
                sum = 0;
            }
            else
            {
                sum += st.Pop() + Math.Max(sum, 1);
            }
        }
        
        return sum;
    }
}