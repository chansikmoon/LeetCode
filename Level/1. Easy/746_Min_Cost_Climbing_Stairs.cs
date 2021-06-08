public class Solution {
    public int MinCostClimbingStairs(int[] cost) {
        int n = cost.Length;
        int prevTwo = 0, prevOne = 0;
        
        for (int i = 0; i < n; i++)
        {
            int tmpOne = prevOne;
            
            prevOne = Math.Min(prevOne, prevTwo) + cost[i];
            prevTwo = tmpOne;
        }
        
        return Math.Min(prevOne, prevTwo);
    }
}