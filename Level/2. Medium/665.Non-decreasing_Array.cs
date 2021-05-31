public class Solution
{
    public bool CheckPossibility(int[] nums)
    {
        int n = nums.Length;
        for (int i = 1, k = 0; i < n; i++)
        {
            if (nums[i - 1] > nums[i])
            {
                if (k++ > 0 ||
                   i > 1 && i < n - 1 &&
                   nums[i - 2] > nums[i] && nums[i - 1] > nums[i + 1])
                    return false;
            }
        }

        return true;
    }
}