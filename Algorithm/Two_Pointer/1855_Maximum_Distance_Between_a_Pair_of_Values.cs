public class Solution
{
    public int MaxDistance(int[] nums1, int[] nums2)
    {
        int i = 0, j = 0, ret = 0, n = nums1.Length, m = nums2.Length;

        while (i < n && j < m)
        {
            if (nums1[i] > nums2[j])
                i++;
            else
            {
                ret = Math.Max(ret, j - i);
                j++;
            }
        }

        return ret;
    }

    private int bruteForce(int[] nums1, int[] nums2)
    {
        int max = 0, j = nums2.Length - 1, tmp = 0;

        for (int i = nums1.Length - 1; i >= 0; i--)
        {
            if (nums2[j] >= nums1[i])
            {
                tmp = j - i;
            }
            else
            {
                if (tmp > max)
                {
                    max = tmp;
                }

                tmp = 0;

                while (i <= j && nums2[j] < nums1[i])
                    j--;
            }
        }

        if (tmp > max)
            max = tmp;

        return max;
    }
}