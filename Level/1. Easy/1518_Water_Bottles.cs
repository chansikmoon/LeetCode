public class Solution {
    public int NumWaterBottles(int numBottles, int numExchange) {
        int ans = numBottles;
        
        while (numBottles > 0 && numBottles >= numExchange)
        {
            int newBottles = numBottles / numExchange;
            ans += newBottles;
            numBottles %= numExchange;
            numBottles += newBottles;
        }
        
        return ans;
    }
}