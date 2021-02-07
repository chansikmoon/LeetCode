public class Solution {
    public int MaximumScore(int a, int b, int c) {
        // If all 3 nums become 0, then result is (a + b + c) / 2
        // If 2 out of 3 are 0, it has to be sum of the min + middle one => total - max
        int total = a + b + c;
        return Math.Min(total / 2, total - Math.Max(a, Math.Max(b, c)));
    }
}