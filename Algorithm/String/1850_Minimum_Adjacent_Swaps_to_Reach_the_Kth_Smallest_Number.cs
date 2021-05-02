public class Solution
{
    public int GetMinSwaps(string num, int k)
    {
        var nums = new int[num.Length];
        for (int i = 0; i < num.Length; i++)
            nums[i] = num[i] - '0';

        while (k-- > 0)
            NextPermutation(nums);

        var sb = new StringBuilder();
        for (int i = 0; i < nums.Length; i++)
            sb.Append(nums[i]);

        return Count(num.ToCharArray(), sb.ToString().ToCharArray());
    }

    private int Count(char[] ori, char[] perm)
    {
        int n = ori.Length, i = 0, ret = 0;

        while (i < n)
        {
            int j = i;

            while (perm[j] != ori[i])
                j++;

            while (j > i)
            {
                char tmp = perm[j];
                perm[j] = perm[j - 1];
                perm[j - 1] = tmp;
                j--;
                ret++;
            }

            i++;
        }

        return ret;
    }

    public void NextPermutation(int[] nums)
    {
        int i = nums.Length - 2;

        // Find the first decreasing element starting from the end of an array
        while (i >= 0 && nums[i] >= nums[i + 1])
            i--;

        if (i >= 0)
        {
            // Find the first bigger nums[j] than nums[i] starting from the end of an array
            int j = nums.Length - 1;
            while (i < j && nums[i] >= nums[j])
                j--;

            Swap(nums, i, j);
        }

        Reverse(nums, i + 1);
    }

    private void Swap(int[] nums, int i, int j)
    {
        int tmp = nums[i];
        nums[i] = nums[j];
        nums[j] = tmp;
    }

    private void Reverse(int[] nums, int i)
    {
        int j = nums.Length - 1;
        while (i < j)
            Swap(nums, i++, j--);
    }
}