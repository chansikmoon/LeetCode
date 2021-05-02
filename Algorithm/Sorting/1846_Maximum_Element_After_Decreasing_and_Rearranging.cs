public class Solution
{
    public int MaximumElementAfterDecrementingAndRearranging(int[] arr)
    {
        Array.Sort(arr);

        if (arr[0] != 1)
            arr[0] = 1;

        for (int i = 1; i < arr.Length; i++)
        {
            if (Math.Abs(arr[i - 1] - arr[i]) > 1)
                arr[i] = arr[i - 1] + 1;
        }

        return arr.Max();
    }
}