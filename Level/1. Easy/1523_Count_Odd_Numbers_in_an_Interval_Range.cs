public class Solution {
    public int CountOdds(int low, int high) {
        return AnotherSolution(low, high);
        // return Count(high) - Count(low - 1);
    }
    
    private int Count(int n)
    {
        return (n + 1) / 2;
    }
    
    private int AnotherSolution(int low, int high)
    {
        int res = (high - low) / 2;

        if ((low % 2) == 1 || (high % 2) == 1)
            res++;

        return res;
    }
}