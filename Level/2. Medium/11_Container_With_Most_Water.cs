public class Solution {
    public int MaxArea(int[] height) {
        int i = 0, j = height.Length - 1, most = 0;
        
        while (i < j)
        {
            most = Math.Max(most, Math.Min(height[i], height[j]) * (j - i));
            if (height[i] < height[j])
                i++;
            else
                j--;
        }
        
        return most;
    }
}