public class Solution {
    public bool KLengthApart(int[] nums, int k) {
        int lastOneIndex = -1;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 1)
            {
                if (lastOneIndex != -1 && i - lastOneIndex - 1 < k)
                    return false;
                
                lastOneIndex = i;
            }
        }
        
        return true;
    }
}