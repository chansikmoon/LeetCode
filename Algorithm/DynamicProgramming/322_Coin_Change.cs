public class Solution
{
    public int CoinChange(int[] coins, int amount)
    {
        if (amount == 0)
            return 0;

        var memo = new int[amount + 1];

        // O(nk), n - amount, k - # of coins
        Iteratively(coins, memo, amount);
        // Recursively(coins, memo, amount);

        return memo[amount] > amount ? -1 : memo[amount];
    }

    private void Iteratively(int[] coins, int[] memo, int amount)
    {
        for (int i = 1; i <= amount; i++)
        {
            memo[i] = amount + 1;
            foreach (int c in coins)
            {
                if (i - c >= 0)
                    memo[i] = Math.Min(memo[i], memo[i - c] + 1);
            }
        }
    }

    private void Recursively(int[] coins, int[] memo, int amount)
    {
        for (int i = 1; i <= amount; i++)
            memo[i] = -1;

        Helper(coins, memo, amount, amount);
    }

    private int Helper(int[] coins, int[] memo, int originalAmount, int remaining)
    {
        if (remaining < 0)
            return originalAmount + 1;
        if (remaining == 0)
            return 0;

        if (memo[remaining] > -1)
            return memo[remaining];

        int ret = originalAmount + 1;

        foreach (int c in coins)
            ret = Math.Min(ret, Helper(coins, memo, originalAmount, remaining - c) + 1);

        memo[remaining] = ret;
        return ret;
    }
}