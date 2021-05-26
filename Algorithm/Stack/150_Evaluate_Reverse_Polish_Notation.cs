public class Solution
{
    public int EvalRPN(string[] tokens)
    {
        var st = new Stack<int>();

        foreach (var t in tokens)
        {
            if (IsOperator(t))
            {
                var second = st.Pop();
                var first = st.Pop();
                int ret = 0;

                switch (t)
                {
                    case "+":
                        ret = first + second;
                        break;
                    case "-":
                        ret = first - second;
                        break;
                    case "*":
                        ret = first * second;
                        break;
                    case "/":
                        ret = first / second;
                        break;
                    default:
                        break;
                }

                st.Push(ret);
            }
            else
            {
                st.Push(StringToInt(t));
            }
        }

        return st.Pop();
    }

    private bool IsOperator(string s)
    {
        return s.Length == 1 &&
            (s == "+" || s == "-" || s == "*" || s == "/");
    }

    private int StringToInt(string s)
    {
        int ret = 0;
        int sign = 1;

        for (int i = 0; i < s.Length; i++)
        {
            if (i == 0 && s[i] == '-')
            {
                sign = -1;
                continue;
            }

            ret = ret * 10 + (s[i] - '0');
        }

        return ret * sign;
    }
}