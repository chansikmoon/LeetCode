public class Solution
{
    public bool IsPowerOfThree(int n)
    {
        return n > 0 && 1162261467 % n == 0;
    }

    public bool Iterative(int n)
    {
        if (n > 0)
            while (n % 3 == 0)
                n /= 3;

        return n == 1;
    }
}