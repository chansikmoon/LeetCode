public class Solution {
    public int[] MostCompetitive(int[] nums, int k) {
        var st = new Stack<int>();
        
        for (int i = 0; i < nums.Length; i++)
        {
            // nums.Length - i + st.Count tells how many elements are left and possibly pop.
            while (st.Count > 0 && nums[i] < st.Peek() && nums.Length - i + st.Count > k)
                st.Pop();
            if (st.Count < k)
                st.Push(nums[i]);
        }
        
        var ret = new int[k];
        for (int i = k - 1; i >= 0; i--)
            ret[i] = st.Pop();
        
        return ret;
    }
}