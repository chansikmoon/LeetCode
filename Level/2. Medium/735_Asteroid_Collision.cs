public class Solution {
    public int[] AsteroidCollision(int[] a) {
        Stack<int> st = new Stack<int>();
        
        for (int i = 0; i < a.Length; i++)
        {
            //  1. if st is empty
            //  2. if a[i] is positive      -> As long as a[i] is not negative, we can Push(a[i])
            //  3. if Peek() is negative    -> which means positive values and negative values are acceptable.
            //  Only case we care about is Peek() > 0 && a[i] < 0
            if (a[i] > 0 || st.Count == 0 || st.Peek() < 0)
                st.Push(a[i]);
            else if (st.Peek() <= Math.Abs(a[i]))
            {
                //  At this point, st.Peek() is positive and a[i] is negative
                //  If st.Peek() is greater than Math.Abs(a[i]), then don't add it.
                //  If st.PeeK() is less than or equal to Math.Abs(a[i]), then we need to pop the top element.
                //  And reconsider the a[i] by i--
                if (st.Peek() < Math.Abs(a[i])) 
                    i--;
                st.Pop();
            }
        }
    
        int[] ret = new int[st.Count];
        
        for (int i = st.Count - 1; i >= 0; i--)
        {
            ret[i] = st.Pop();
        }
        
        return ret;
    }
}