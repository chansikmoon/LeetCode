public class Solution {
    public int MaxDistToClosest(int[] seats) {
        int n = seats.Length, left = -1, ret = 0;
        
        for (int right = 0; right < n; right++)
        {
            if (seats[right] == 1)
            {
                ret = left < 0 ? right : Math.Max(ret, (right - left) / 2);
                left = right;
            }
        }
        
        return Math.Max(ret, n - left - 1);
    }
}