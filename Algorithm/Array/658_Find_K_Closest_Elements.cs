public class Solution
{
    public IList<int> FindClosestElements(int[] arr, int k, int x)
    {
        int n = arr.Length;
        int l = 0, r = n - k;

        while (l < r)
        {
            int m = (l + r) / 2;
            // let's say x = 50

            // Case 1: arr[m] = 1 and arr[m+k] = 54
            //         arr[m] ... ... ... x ... arr[m+k]
            //         x - arr[m] (50 - 1) > arr[m+k] - x (54 - 50)
            //         Meaning ideal to shift to the right.

            // Case 2: arr[m] = 49 and arr[m+k] = 100
            //         arr[m] ... x ... ... ... arr[m+k]
            //         x - arr[m] (50 - 49) <= arr[m+k] - x (100 - 50)
            //         Meaning ideal to shift to the left.

            // Should not compare with absolute values
            // [1,1,2,2,2,2,2,3,3] k = 3, x = 3
            //        m     m+k
            // Should be: arr[m] - x (3 - 2) > arr[m-k] - x (2 - 3)
            // Otherwise: |3 - 2| > |2 - 3| will shift to the left where it should shift to the right.

            if (x - arr[m] > arr[m + k] - x)
                l = m + 1;
            else
                r--;
        }

        var ret = new int[k];
        for (int i = 0; i < k; i++)
            ret[i] = arr[l++];

        return ret;
    }
}