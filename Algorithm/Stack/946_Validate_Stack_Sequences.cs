public class Solution {
    public bool ValidateStackSequences(int[] pushed, int[] popped) {
        int push = 0, pop = 0;
        
        for (int i = 0; i < pushed.Length; i++)
        {
            pushed[push++] = pushed[i];
            
            while (push > 0 && pushed[push-1] == popped[pop])
            {
                push--;
                pop++;
            }
        }
        
        return push == 0;
    }
    
    // revisited on 03/16/2022
    private bool BruteForce(int[] pushed, int[] popped)
    {
        var st = new Stack<int>();

        for (int i = 0, j = 0; i < pushed.Length; i++)
        {
            st.Push(pushed[i]);
            
            while (st.Count > 0 && st.Peek() == popped[j])
            {
                st.Pop();
                j++;
            }
        }
            
        return st.Count == 0;
    }
}