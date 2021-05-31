public class Solution
{
    public int SmallestCommonElement(int[][] mat)
    {
        var arr = mat[0];

        for (int i = 0; i < arr.Length; i++)
        {
            if (BinarySearch(mat, 1, arr[i]))
                return arr[i];
        }

        return -1;
    }

    private bool BinarySearch(int[][] mat, int row, int target)
    {
        if (row >= mat.Length)
            return true;

        var arr = mat[row];

        int l = 0, r = arr.Length - 1;

        while (l <= r)
        {
            int m = l + (r - l) / 2;
            if (arr[m] == target)
                return BinarySearch(mat, row + 1, target);
            else if (arr[m] < target)
                l = m + 1;
            else
                r = m - 1;
        }

        return false;
    }
}