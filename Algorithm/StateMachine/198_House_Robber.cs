public class Solution {
    public int Rob(int[] nums) {
        int s1 = 0, s2 = 0;
        
        foreach (int num in nums)
        {
            int tmp = s2;
            s2 = s1;
            s1 = Math.Max(s1, tmp + num);
        }
        
        return s1;
    }
}