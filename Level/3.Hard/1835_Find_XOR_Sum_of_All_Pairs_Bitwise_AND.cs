public class Solution
{
    public int GetXORSum(int[] arr1, int[] arr2)
    {
        int xorA = 0, xorB = 0;

        foreach (int n in arr1)
            xorA ^= n;

        foreach (int n in arr2)
            xorB ^= n;

        return xorA & xorB;
    }
}