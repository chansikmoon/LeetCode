public class Solution {
    public int MinEatingSpeed(int[] piles, int h) {
        int left = 1, right = 1;
        
        foreach (int p in piles)
            right = Math.Max(right, p);
        
        while (left < right)
        {
            int mid = (left + right) / 2;
            int hour = 0;
            
            foreach (int p in piles)
            {
                hour += p / mid;
                hour += (p % mid > 0 ? 1: 0);
            }
            
            if (hour > h)
                left = mid + 1;
            else
                right = mid;
        }
        
        return left;
    }
}