public class Solution
{
    public bool IsIdealPermutation(int[] A)
    {
        for (int i = 0; i < A.Length; i++)
        {
            if (Math.Abs(A[i] - i) > 1)
                return false;
        }

        return true;
    }
}