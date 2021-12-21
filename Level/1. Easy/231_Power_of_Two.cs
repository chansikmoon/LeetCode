public class Solution {
    public bool IsPowerOfTwo(int n) {
        // -n = ~n + 1
        return n > 0 && (n & -n) == n;
    }

    public bool IsPowerOfTwo1(int n) {
        return n > 0 && (n & (n - 1)) == 0;
    }
}