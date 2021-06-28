public class Solution {
    // Optimize space and clean the code
    public int Candy(int[] ratings) {
        int n = ratings.Length;
        
        var count = new int[n];
        
        for (int i = 1; i < n; i++)
        {
            if (ratings[i - 1] < ratings[i])
                count[i] = count[i - 1] + 1;
        }
        
        for (int i = n - 1; i > 0; i--)
        {
            if (ratings[i - 1] > ratings[i])
                count[i - 1] = Math.Max(count[i - 1], count[i] + 1);
        }
        
        return count.Sum() + n;
    }

    // I was surprised that I somehow came up with this bruteforce solution 
    public int BruteForce(int[] ratings) {
        int n = ratings.Length;
        
        var countLeft = new int[n];
        
        for (int i = 1; i < n; i++)
        {
            if (ratings[i - 1] < ratings[i])
                countLeft[i] += countLeft[i - 1] + 1;
        }
        
        var countRight = new int[n];
        
        for (int i = n - 2; i >= 0; i--)
        {
            if (ratings[i] > ratings[i + 1])
                countRight[i] += countRight[i + 1] + 1;
        }
        
        var ret = 0;
        
        for (int i = 0; i < n; i++)
            ret += Math.Max(countLeft[i], countRight[i]);
        
        return ret + n;
    }
}