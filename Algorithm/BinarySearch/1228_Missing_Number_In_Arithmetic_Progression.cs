public class Solution
{
    public int MissingNumber(int[] arr)
    {
        int n = arr.Length;
        int diff = (arr[n - 1] - arr[0]) / n;

        for (int i = 0; i < n - 1; i++)
        {
            if (arr[i + 1] - arr[i] != diff)
                return arr[i] + diff;
        }

        return arr[0] + diff;
    }

    public int BinarySearch(int[] arr)
    {
        int n = arr.Length, diff = (arr[n - 1] - arr[0]) / n, left = 0, right = n;

        while (left < right)
        {
            int mid = left + (right - left) / 2;
            if (arr[mid] == arr[0] + diff * mid)
                left = mid + 1;
            else
                right = mid;
        }

        return arr[0] + diff * left;
    }
}