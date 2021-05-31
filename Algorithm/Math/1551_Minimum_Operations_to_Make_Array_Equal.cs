public class Solution
{
    public int MinOperations(int n)
    {
        /*
        n is even.
        [1, 3, 5, 7]
        target = 4 (sum of arr / n)

        3, 5 => 1 step
        1, 7 => 3 steps

        Only need to sum first half of odd nums.
        1 + 3 = 4

        Sum of odd n => n * n
        Thus, half of n is (n/2) * (n/2)

        n is odd.
        [1, 3, 5, 7, 9]
        target = 5

        3, 7 => 2 steps
        1, 9 => 4 steps

        Only need to sum first half of even nums.

        2 + 4 = 6 steps

        Sum of even n => n(n + 1)
        Thus, half of n is (n/2) (n/2 + 1)
        */
        int half = n / 2;
        return n % 2 == 0 ? half * half : half * (half + 1);
    }

    public int bruteForce(int n)
    {
        var arr = new int[n];
        int sum = 0;

        for (int i = 0; i < n; i++)
        {
            arr[i] = 2 * i + 1;
            sum += arr[i];
        }

        int target = sum / n, ret = 0, mid = n % 2 == 0 ? n / 2 - 1 : n / 2;

        for (int i = mid; i >= 0; i--)
            ret += target - arr[i];

        return ret;
    }
}