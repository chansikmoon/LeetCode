public class Solution {
    public int ReachNumber(int target) {
        target = Math.Abs(target);
        int step = 0, sum = 0;
        
        while (sum < target)
        {
            step++;
            sum += step;
        }
        
        while ((sum - target) % 2 != 0)
        {
            step++;
            sum += step;
        }
        
        return step;
    }
}