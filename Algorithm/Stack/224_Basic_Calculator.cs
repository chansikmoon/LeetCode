public class Solution {
    public int Calculate(string s) {
        Stack<int> st = new Stack<int>();
        int ret = 0, num = 0, sign = 1;
        
        st.Push(sign);
        
        for (int i = 0; i < s.Length; i++)
        {
            if (Char.IsDigit(s[i]))
                num = num * 10 + (s[i] - '0');
            else if (s[i] == '+' || s[i] == '-')
            {
                ret += num * sign;
                // st.Peek() is needed b/c of the distributive law
                // ex) 1 - (4 + 5 - 2) ==> 1 - 4 - 5 + 2
                sign = st.Peek() * (s[i] == '+' ? 1 : -1);
                num = 0;
            }
            else if (s[i] == '(')
                st.Push(sign);
            else if (s[i] == ')')
                st.Pop();
        }
        
        ret += num * sign;
        return ret;
    }
}