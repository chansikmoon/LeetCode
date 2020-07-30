public class Solution {
    public int MaxProfit(int[] prices) {
        int held = Int32.MinValue, sold = 0, reset = 0;
        
        foreach (int price in prices)
        {
            int lastSold = sold;
            // - purchased stock + current price
            sold = held + price;
            // held price vs from prev cooldown to purchase
            held = Math.Max(held, reset - price);
            // cooldown vs don't sell
            reset = Math.Max(reset, lastSold);
        }

        return Math.Max(reset, sold);
    }
}

/*

    3 states: held, sold, reset
    3 actions: buy, sell, rest

    held: either keep the previous price or purchase from cooldown
    sold: sell held stock
    reset: Either keep the previous price or cooldown
*/