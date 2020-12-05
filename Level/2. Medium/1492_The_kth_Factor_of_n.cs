public class Solution {
    public int KthFactor(int n, int k) {
        // Real Number sqrt is expensive comparing to n * n

        // n = 4, k = 4

        // i = 1    1 <= 4      k = 3
        // i = 2    4 <= 4      k = 2
        int i = 1;
        for (; i * i <= n; ++i)
        {
            if (n % i == 0 && --k == 0)
                return i;
        }

        // i = 2    2 * 2 >= 4
        // i = 1
        while (i * i >= n)
            i--;

        // i = 1    4 % 1 = 0 && k = 1
        for (; i > 0; --i)
        {
            if (n % i == 0 && --k == 0)
                return n / i;
        }

        return -1;
    }

    public int BruteForce(int n, int k)
    {
        for (int i = 1; i <= n; i++)
        {
            if (n % i == 0 && --k == 0)
                return i;
        }
        
        return -1;
    }
}