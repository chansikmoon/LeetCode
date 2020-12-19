public class Solution {
    public bool IncreasingTriplet(int[] nums) {
        int i = Int32.MaxValue, j = Int32.MaxValue;
        
        foreach (int num in nums)
        {
            if (i >= num)
                i = num;
            else if (j >= num)
                j = num;
            else
                return true;
        }
        
        return false;
    }
}