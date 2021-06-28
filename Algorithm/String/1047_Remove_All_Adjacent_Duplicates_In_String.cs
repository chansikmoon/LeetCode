public class Solution
{
    public string RemoveDuplicates(string s)
    {
        var st = new Stack<char>();

        for (int i = 0; i < s.Length; i++)
        {
            if (st.Count > 0 && st.Peek() == s[i])
            {
                st.Pop();
                continue;
            }

            st.Push(s[i]);
        }

        var charArr = st.ToArray();
        Array.Reverse(charArr);
        return new string(charArr);
    }
}