public class Solution {
    public bool Find132pattern(int[] nums) {
        Stack<int> st = new Stack<int>();
        int[] minArr = new int[nums.Length];
        minArr[0] = nums[0];
        for (int i = 1; i < nums.Length; i++)
            minArr[i] = Math.Min(minArr[i-1], nums[i]);
        
        for (int j = nums.Length - 1; j >= 0; j--)
        {
            if (nums[j] > minArr[j])
            {
                // st contains all possible nums[k] elements so Pop() all elements if st.Peek() <= minArr[j]
                while (st.Count > 0 && st.Peek() <= minArr[j])
                    st.Pop();
                
                // At this point, we know
                //      1) minArr[j] < st.Peek() and 
                //      2) minArr[j] < nums[j]
                
                // We just need to know that st.Peek() is less than nums[j]
                if (st.Count > 0 && st.Peek() < nums[j])
                    return true;
                st.Push(nums[j]);
            }
        }
        
        return false;
    }
}